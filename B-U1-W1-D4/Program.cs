using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_U1_W1_D4
{
    internal class Program
    {

       
        static void Main(string[] args)
        {
            Utente.MostraAzioniSportello();
        }

        public static class Utente
        {
            private static List<LoginUtente> listUsersLogin = new List<LoginUtente>();

            public static void Login() {
               
                try
                {
                    LoginUtente loginUtente = new LoginUtente();

                    Console.WriteLine("\nInserisci una username: ");
                    loginUtente.Username = Console.ReadLine();

                    Console.WriteLine("\nInserisci una password: ");
                    loginUtente.Password = Console.ReadLine();

                    Console.WriteLine("\nConferma password: ");
                    loginUtente.ConfermaPassword = Console.ReadLine();

                    if(loginUtente.Username != null && loginUtente.Password == loginUtente.ConfermaPassword) {
                        Console.WriteLine("Ti sei loggato correttamente\n");
                        loginUtente.IsLogged = true;
                        loginUtente.DataLogin = DateTime.Now;

                        listUsersLogin.Add(loginUtente);
                        MostraAzioniSportello();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\nHai sbagliato password, riprovare\n");
                    Login();
                }
            }

            public static void Logout() {

                try
                {
                    int ultimoUtente = listUsersLogin.Count - 1;

                    listUsersLogin[ultimoUtente].IsLogged = false;

                    Console.Write($"\nL'utente {listUsersLogin[ultimoUtente].Username} ha eseguito correttamente il logout\n");
                    MostraAzioniSportello();
                }
                catch (Exception)
                {

                    Console.WriteLine("\n'L'utente non si é proprio autenticato.\n");
                }
            }

            public static void CheckTimeLogin() {
                try
                {
                    int ultimoUtente = listUsersLogin.Count - 1;
                    Console.Write($"\nL'utente {listUsersLogin[ultimoUtente].Username} ha eseguito il login alle {listUsersLogin[ultimoUtente].DataLogin.ToString()}\n");
                    MostraAzioniSportello();
                }
                catch (Exception)
                {
                    Console.WriteLine("\n'L'utente non si é proprio autenticato.\n");
                }

            }

            public static void ListaAccessi() {
              foreach (LoginUtente item in listUsersLogin)
                {
                    Console.WriteLine($"\nUsername: {item.Username}\n");
                    Console.WriteLine($"Password: {item.Password}");
                    Console.WriteLine($"Autenticazione: {item.IsLogged}\n");
                }

                MostraAzioniSportello();
            }

            public static void MostraAzioniSportello()
            {
                try
                {
                    Console.WriteLine("=========== OPERAZIONI =============");
                    Console.WriteLine("Scegli l'operazione da effettuare");
                    Console.WriteLine("1. Login");
                    Console.WriteLine("2. Logout");
                    Console.WriteLine("3. Verifica ora e data di login");
                    Console.WriteLine("4. Lista degli accessi");
                    Console.WriteLine("5. Esci");
                    Console.WriteLine("====================================\n");
                    
                    int scelta = int.Parse(Console.ReadLine());

                    switch (scelta)
                    {
                        case 1:
                            Login();
                            break;
                        case 2:
                            Logout();
                            break;
                        case 3: 
                            CheckTimeLogin(); 
                            break;
                        case 4:
                            ListaAccessi();
                            break;
                        case 5:
                            Console.WriteLine("\nFine Operazioni");
                            Console.ReadLine();
                            break;
                        default:
                            break;
                    }
                } catch(Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        public class LoginUtente
        {
            public string Username { get; set; }
            public  string Password { get; set; } 
            public string ConfermaPassword { get; set; }

            public bool IsLogged { get; set; }

            public DateTime DataLogin { get; set; }
        }
    }
}
