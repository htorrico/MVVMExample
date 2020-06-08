using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MVVMExample.ViewModels
{
   public class Page1ViewModel : ViewModelBase
    {
        #region Propiedades
        
        int valor1;
        public int Valor1
        {
            get { return valor1; }
            set
            {
                if (valor1 != value)
                {
                    valor1 = value;
                    //ViewModelBase
                    //Notifica el Cambio
                    OnPropertyChanged();
                }
            }
        }

        int valor2;
        public int Valor2
        {
            get { return valor2; }
            set
            {
                if (valor2 != value)
                {
                    valor2 = value;
                    OnPropertyChanged();
                }
            }
        }


        int suma;
        public int ResultSuma
        {
            get { return suma; }
            set
            {
                if (suma != value)
                {
                    suma = value;
                    OnPropertyChanged();
                }
            }
        }

        int resta;
        public int ResultResta
        {
            get { return resta; }
            set
            {
                if (resta != value)
                {
                    resta = value;
                    OnPropertyChanged();
                }
            }
        }

        #endregion

        #region Comandos 
        public ICommand Sumar { protected set; get; }
        public ICommand Restar { protected set; get; }
        public ICommand ButtonClickCommand { protected set; get; }

        #endregion
        public Page1ViewModel ()
        {
            Sumar = new Command(() =>
            {
                ResultSuma = Valor1 + Valor2;                
            });

            Restar = new Command(() =>
             {
                 ResultResta = Valor1 - Valor2;
             });
           
            ButtonClickCommand = new Command<string>(
           execute: (string arg) =>
           {
               ResultResta += Convert.ToInt32( arg);

               //RefreshCanExecutes();
           },
           canExecute: (string arg) =>
           {
               if (Convert.ToInt32(arg) % 2 ==0)
               {
                   return true;
               }
               else
               {
                   return false;

               }
               

               //return !(arg == "." && Entry.Contains("."));
           });
        }

    }
}
