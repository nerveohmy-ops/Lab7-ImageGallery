using System.IO;

namespace ImageGallery;

public partial class Form1 : Form
{
    private const int MinZoomPercent = 50;
    private const int MaxZoomPercent = 200;
    private const int ZoomStepPercent = 10;

    private static readonly HashSet<string> SupportedExtensions = new(StringComparer.OrdinalIgnoreCase)
    {
        ".jpg", ".jpeg", ".png", ".bmp", ".gif", ".webp"
    };

    private string patch = string.Empty;
    private Image? _originalImage;
    private int _zoomPercent = 100;
    private bool _isManualZoom;
    private bool _isUpdatingControls;

    private sealed record SizeModeOption(PictureBoxSizeMode Mode, string DisplayText)
    {
        public override string ToString() => DisplayText;
    }

    public Form1()
    {
        InitializeComponent();
        InitializeSizeModes();
        UpdateZoomLabel();
    }

    private void InitializeSizeModes()
    {
        _isUpdatingControls = true;
        comboBoxSizeMode.Items.Clear();
        comboBoxSizeMode.Items.AddRange(new object[]
        {
            new SizeModeOption(PictureBoxSizeMode.Zoom, "Zoom (с сохранением пропорций)"),
            new SizeModeOption(PictureBoxSizeMode.StretchImage, "StretchImage (растягивание)"),
            new SizeModeOption(PictureBoxSizeMode.CenterImage, "CenterImage (по центру)"),
            new SizeModeOption(PictureBoxSizeMode.Normal, "Normal (оригинальный размер)")
        });
        comboBoxSizeMode.SelectedIndex = 0;
        _isUpdatingControls = false;
    }

    private bool FillListBox(string directoryPath)
    {
        var directory = new DirectoryInfo(directoryPath);
        if (!directory.Exists)
        {
            listBox1.Items.Clear();
            return false;
        }

        FileInfo[] files = directory
            .GetFiles()
            .Where(file => SupportedExtensions.Contains(file.Extension))
            .OrderBy(file => file.Name, StringComparer.OrdinalIgnoreCase)
            .ToArray();

        listBox1.Items.Clear();
        foreach (FileInfo file in files)
        {
            listBox1.Items.Add(file.Name);
        }

        label1.Text = directoryPath;

        if (files.Length == 0)
        {
            return false;
        }

        listBox1.SelectedIndex = 0;
        return true;
    }

    private void listBox1_SelectedIndexChanged(object? sender, EventArgs e)
    {
        if (listBox1.SelectedItem is not string fileName || string.IsNullOrEmpty(patch))
        {
            ClearCurrentImage();
            return;
        }

        string fullPath = Path.Combine(patch, fileName);
        LoadPreviewImage(fullPath);
    }

    private void LoadPreviewImage(string fullPath)
    {
        try
        {
            using var stream = new FileStream(fullPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            using var loaded = Image.FromStream(stream);
            var copy = new Bitmap(loaded);

            pictureBox1.Image = null;
            _originalImage?.Dispose();
            _originalImage = copy;
            pictureBox1.Image = _originalImage;

            ApplyCurrentDisplayState();
        }
        catch (Exception ex)
        {
            ClearCurrentImage();
            MessageBox.Show(
                this,
                $"Не удалось загрузить изображение:\n{ex.Message}",
                "Ошибка загрузки",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }
    }

    private void ClearCurrentImage()
    {
        pictureBox1.Image = null;
        _originalImage?.Dispose();
        _originalImage = null;
        UpdateZoomLabel();
    }

    private void button1_Click(object? sender, EventArgs e)
    {
        using var fbd = new FolderBrowserDialog
        {
            Description = "Выберите папку"
        };

        if (!string.IsNullOrEmpty(patch) && Directory.Exists(patch))
        {
            fbd.SelectedPath = patch;
        }

        if (fbd.ShowDialog(this) != DialogResult.OK)
        {
            return;
        }

        patch = fbd.SelectedPath;
        label1.Text = patch;

        if (!FillListBox(patch))
        {
            ClearCurrentImage();
        }
    }

    private void trackBarZoom_Scroll(object? sender, EventArgs e)
    {
        if (_isUpdatingControls)
        {
            return;
        }

        int snapped = SnapZoomToStep(trackBarZoom.Value);
        SetManualZoom(snapped);
    }

    private void buttonZoomIn_Click(object? sender, EventArgs e)
    {
        int nextZoom = Math.Min(MaxZoomPercent, _zoomPercent + ZoomStepPercent);
        SetManualZoom(nextZoom);
    }

    private void buttonZoomOut_Click(object? sender, EventArgs e)
    {
        int nextZoom = Math.Max(MinZoomPercent, _zoomPercent - ZoomStepPercent);
        SetManualZoom(nextZoom);
    }

    private void buttonOriginalSize_Click(object? sender, EventArgs e)
    {
        SetManualZoom(100);
    }

    private void buttonFitWindow_Click(object? sender, EventArgs e)
    {
        _isManualZoom = false;
        SelectSizeModeInComboBox(PictureBoxSizeMode.Zoom);
        ApplySizeModeDisplay(PictureBoxSizeMode.Zoom);
    }

    private void comboBoxSizeMode_SelectedIndexChanged(object? sender, EventArgs e)
    {
        if (_isUpdatingControls || comboBoxSizeMode.SelectedItem is not SizeModeOption option)
        {
            return;
        }

        _isManualZoom = false;
        ApplySizeModeDisplay(option.Mode);
    }

    private void panelPreview_Resize(object? sender, EventArgs e)
    {
        if (_isManualZoom)
        {
            CenterPictureBoxInPanel();
        }
        else
        {
            UpdateZoomLabel();
        }
    }

    private void SetManualZoom(int percent)
    {
        _zoomPercent = Math.Clamp(SnapZoomToStep(percent), MinZoomPercent, MaxZoomPercent);
        _isManualZoom = true;

        _isUpdatingControls = true;
        trackBarZoom.Value = _zoomPercent;
        _isUpdatingControls = false;

        ApplyManualZoomDisplay();
    }

    private void ApplyCurrentDisplayState()
    {
        if (_isManualZoom)
        {
            ApplyManualZoomDisplay();
        }
        else if (comboBoxSizeMode.SelectedItem is SizeModeOption option)
        {
            ApplySizeModeDisplay(option.Mode);
        }
    }

    private void ApplyManualZoomDisplay()
    {
        if (_originalImage is null)
        {
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            UpdateZoomLabel();
            return;
        }

        panelPreview.AutoScrollPosition = Point.Empty;
        pictureBox1.Dock = DockStyle.None;
        pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

        int scaledWidth = Math.Max(1, (int)Math.Round(_originalImage.Width * (_zoomPercent / 100.0)));
        int scaledHeight = Math.Max(1, (int)Math.Round(_originalImage.Height * (_zoomPercent / 100.0)));
        pictureBox1.Size = new Size(scaledWidth, scaledHeight);

        CenterPictureBoxInPanel();
        UpdateZoomLabel();
    }

    private void ApplySizeModeDisplay(PictureBoxSizeMode mode)
    {
        panelPreview.AutoScrollPosition = Point.Empty;
        pictureBox1.Dock = DockStyle.Fill;
        pictureBox1.SizeMode = mode;

        if (mode is PictureBoxSizeMode.Normal or PictureBoxSizeMode.CenterImage)
        {
            _zoomPercent = 100;
            _isUpdatingControls = true;
            trackBarZoom.Value = 100;
            _isUpdatingControls = false;
        }

        UpdateZoomLabel();
    }

    private void CenterPictureBoxInPanel()
    {
        if (pictureBox1.Dock != DockStyle.None)
        {
            return;
        }

        Size client = panelPreview.ClientSize;
        int x = pictureBox1.Width < client.Width ? (client.Width - pictureBox1.Width) / 2 : 0;
        int y = pictureBox1.Height < client.Height ? (client.Height - pictureBox1.Height) / 2 : 0;
        pictureBox1.Location = new Point(x, y);
    }

    private void SelectSizeModeInComboBox(PictureBoxSizeMode mode)
    {
        _isUpdatingControls = true;
        for (int i = 0; i < comboBoxSizeMode.Items.Count; i++)
        {
            if (comboBoxSizeMode.Items[i] is SizeModeOption option && option.Mode == mode)
            {
                comboBoxSizeMode.SelectedIndex = i;
                break;
            }
        }
        _isUpdatingControls = false;
    }

    private void UpdateZoomLabel()
    {
        if (_isManualZoom || _originalImage is null)
        {
            labelZoom.Text = $"Масштаб: {_zoomPercent}%";
            return;
        }

        if (comboBoxSizeMode.SelectedItem is not SizeModeOption option)
        {
            labelZoom.Text = $"Масштаб: {_zoomPercent}%";
            return;
        }

        switch (option.Mode)
        {
            case PictureBoxSizeMode.Zoom:
                int fitPercent = CalculateFitZoomPercent();
                labelZoom.Text = $"Масштаб: {fitPercent}% (по окну)";
                break;
            case PictureBoxSizeMode.StretchImage:
                labelZoom.Text = "Масштаб: растянуто";
                break;
            case PictureBoxSizeMode.CenterImage:
            case PictureBoxSizeMode.Normal:
            default:
                labelZoom.Text = "Масштаб: 100%";
                break;
        }
    }

    private int CalculateFitZoomPercent()
    {
        if (_originalImage is null || _originalImage.Width <= 0 || _originalImage.Height <= 0)
        {
            return 100;
        }

        Size viewport = panelPreview.ClientSize;
        if (viewport.Width <= 0 || viewport.Height <= 0)
        {
            return 100;
        }

        double ratioX = (double)viewport.Width / _originalImage.Width;
        double ratioY = (double)viewport.Height / _originalImage.Height;
        double ratio = Math.Min(ratioX, ratioY);
        return Math.Max(1, (int)Math.Round(ratio * 100.0));
    }

    private static int SnapZoomToStep(int value)
    {
        int snapped = (int)Math.Round(value / (double)ZoomStepPercent) * ZoomStepPercent;
        return Math.Clamp(snapped, MinZoomPercent, MaxZoomPercent);
    }
}
