using System;
using System.Windows;
using System.Windows.Threading;

namespace HotelApp
{
    public partial class MainWindow : Window
    {
        private DispatcherTimer cleanTimer;

        public MainWindow()
        {
            InitializeComponent();

            cleanTimer = new DispatcherTimer();
            cleanTimer.Interval = TimeSpan.FromMilliseconds(100);
            cleanTimer.Tick += CleanTimer_Tick;
        }

        // 1. Xử lý Slider Giảm giá
        private void SliderDiscount_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (txtDiscount != null)
            {
                //txtDiscount.Text = $"{(int)e.NewValue}%";
                txtDiscount.Text = SliderDiscount.Value.ToString();
            }
            
        }

        // 2. Xử lý ProgressBar Dọn phòng
        private void BtnStartCleaning_Click(object sender, RoutedEventArgs e)
        {
            PbHousekeeping.Value = 0;
            cleanTimer.Start();
        }

        private void CleanTimer_Tick(object sender, EventArgs e)
        {
            if (PbHousekeeping.Value < PbHousekeeping.Maximum)
                PbHousekeeping.Value += 2;
            else
                cleanTimer.Stop();
        }

        private void CbUrgent_Checked(object sender, RoutedEventArgs e)
        {
            PbHousekeeping.IsIndeterminate = true; 
        }

        private void CbUrgent_Unchecked(object sender, RoutedEventArgs e)
        {
            PbHousekeeping.IsIndeterminate = false;
        }

        // 3. Xử lý ScrollBar cuộn hóa đơn
        private void SbBill_Scroll(object sender, System.Windows.Controls.Primitives.ScrollEventArgs e)
        {
            if (BillTransform != null)
            {
                
                BillTransform.Y = -e.NewValue;
            }
        }
    }
}
