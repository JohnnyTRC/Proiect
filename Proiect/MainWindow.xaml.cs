using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MeniuModel;
using System.Data.Entity;
using System.Data;

namespace Proiect
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    enum ActionState
    {
        New,
        Edit,
        Delete,
        Nothing
    }
    public partial class MainWindow : Window
    {
        ActionState action = ActionState.Nothing;
        MeniuEntitiesModel ctx = new MeniuEntitiesModel();
        CollectionViewSource clientiVSource;
        CollectionViewSource meniuVSource;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            meniuVSource =
            ((System.Windows.Data.CollectionViewSource)(this.FindResource("meniuViewSource")));
            meniuVSource.Source = ctx.Menius.Local;
            ctx.Menius.Load();
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            action = ActionState.New;
        }
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            action = ActionState.Edit;
        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            action = ActionState.Delete;
        }

        private void btnPrevM_Click(object sender, RoutedEventArgs e)
        {
            meniuVSource.View.MoveCurrentToPrevious();
        }

        private void btnNextM_Click(object sender, RoutedEventArgs e)
        {
            meniuVSource.View.MoveCurrentToNext();
        }
        private void SaveMeniu()
        {
            Meniu meniu= null;
            if (action == ActionState.New)
            {
                try
                {
                    //instantiem Customer entity
                    meniu = new Meniu()
                    {
                        NumeProdus = numeProdusTextBox.Text.Trim(),
                        Pret = float.Parse(pretTextBox.Text.Trim()),
                        Descriere = descriereTextBox.Text.Trim()

                    };
                    //adaugam entitatea nou creata in context
                    ctx.Menius.Add(meniu);
                    meniuVSource.View.Refresh();
                    //salvam modificarile
                    ctx.SaveChanges();
                }
                //using System.Data;
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
           if (action == ActionState.Edit)
            {
                try
                {
                    meniu = (Meniu)meniuDataGrid.SelectedItem;
                    meniu.NumeProdus = numeProdusTextBox.Text.Trim();
                    meniu.Pret = float.Parse(pretTextBox.Text.Trim());
                    meniu.Descriere = descriereTextBox.Text.Trim();
                    //salvam modificarile
                    ctx.SaveChanges();
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (action == ActionState.Delete)
            {
                try
                {
                    meniu = (Meniu)meniuDataGrid.SelectedItem;
                    ctx.Menius.Remove(meniu);
                    ctx.SaveChanges();
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                meniuVSource.View.Refresh();
            }

        }
        private void gbOperations_Click(object sender, RoutedEventArgs e)
        {
            Button SelectedButton = (Button)e.OriginalSource;
            Panel panel = (Panel)SelectedButton.Parent;

            foreach (Button B in panel.Children.OfType<Button>())
            {
                if (B != SelectedButton)
                    B.IsEnabled = false;
            }
            gbActions.IsEnabled = true;
        }

        private void ReInitialize()
        {

            Panel panel = gbOperations.Content as Panel;
            foreach (Button B in panel.Children.OfType<Button>())
            {
                B.IsEnabled = true;
            }
            gbActions.IsEnabled = false;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            ReInitialize();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            TabItem ti = tbCtrlMeniu.SelectedItem as TabItem;

            switch (ti.Header)
            {
                case "Clienti":
                    
                    break;
                case "Meniu":
                    SaveMeniu();
                    break;
                case "Orders":
                    break;
            }
            ReInitialize();
        }


    }
}
