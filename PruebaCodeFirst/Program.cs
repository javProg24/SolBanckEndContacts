// See https://aka.ms/new-console-template for more information
using DataCodeFirst.Contexts;
using DataCodeFirst.Models;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;
using (var context = new ContactContexts())
{
    var contacts = new List<Contact>
    {
        new Contact { Nombre = "Jose", Apellido = "Malave", Numero = 988338901, Estado = true },
        new Contact { Nombre = "Jean", Apellido = "Romero", Numero = 986643804, Estado = true },
        new Contact { Nombre = "Nicole", Apellido = "Tomala", Numero = 962521356, Estado = true },
        new Contact { Nombre = "Carolina", Apellido = "Gonzalez", Numero = 986409059, Estado = true },
        new Contact { Nombre = "Pedro", Apellido = "Aviles", Numero = 995340179, Estado = true }
    };
    context.Contacts.AddRange(contacts);
    context.SaveChanges();
    /*var contact = context.Contacts.ToList();
    foreach(var c in contact)
    {
        Console.WriteLine(c.ID+" - "+c.Nombre+" - "+c.Apellido+" - "+c.Numero+" - "+c.Estado);
    }*/
    var contact = context.Contacts.ToList();
    string[,] contactTable = new string[contact.Count, 5];
    for (int i = 0; i < contact.Count; i++)
    {
        contactTable[i, 0] = contact[i].ID.ToString();
        contactTable[i, 1] = contact[i].Nombre.ToString();
        contactTable[i, 2]= contact[i].Apellido.ToString();
        contactTable[i, 3]= contact[i].Numero.ToString();
        contactTable[i,4]= contact[i].Estado.ToString();
    }

    int col1Width = contactTable.Cast<string>().Max(c => c.Length);
    int col2Width = contactTable.Cast<string>().Max(c => c.Length);
    int col3Width = contactTable.Cast<string>().Max(c => c.Length);
    int col4Width = contactTable.Cast<string>().Max(c => c.Length);
    int col5Width = contactTable.Cast<string>().Max(c => c.Length);

    Console.WriteLine("{0,-" + col1Width + "} | {1,-" + col2Width + "} | {2,-" + col3Width + "} | {3,-" + col4Width + "} | {4,-" + col5Width + "}",
                      "ID", "Nombre", "Apellido", "Numero", "Estado");
    Console.WriteLine(new string('-', col1Width + col2Width + col3Width + col4Width + col5Width + 9));

    for (int i = 0; i < contact.Count; i++) 
    {
        Console.WriteLine("{0,-" + col1Width + "} | {1,-" + col2Width + "} | {2,-" + col3Width + "} | {3,-" + col4Width + "} | {4,-" + col5Width + "}",
                          contactTable[i, 0], contactTable[i, 1], contactTable[i, 2], contactTable[i, 3], contactTable[i, 4]);
    }
}