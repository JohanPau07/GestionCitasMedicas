using System;
using Gestión_de_Citas_Médicas.Data;
using Gestión_de_Citas_Médicas.Interfaces;
using Gestión_de_Citas_Médicas.Models;
using Gestión_de_Citas_Médicas.Services;
using Gestión_de_Citas_Médicas.Validations;

IRepositorio<Paciente> repoPacientes = new RepositorioEnMemoria<Paciente>();
IRepositorio<Medico> repoMedicos = new RepositorioEnMemoria<Medico>();
IRepositorio<Especialidad> repoEspecialidades = new RepositorioEnMemoria<Especialidad>();
IRepositorio<Cita> repoCitas = new RepositorioEnMemoria<Cita>();

var servicioPacientes = new ServicioPacientes(repoPacientes);
var servicioMedicos = new ServicioMedicos(repoMedicos);
var servicioEspecialidades = new ServicioEspecialidades(repoEspecialidades);
var servicioCitas = new ServicioCitas(repoCitas, new ValidadorDisponibilidad());

INotificador notificador = new NotificadorCorreo();
var servicioRecordatorios = new ServicioRecordatorios(notificador);

var cardiologia = servicioEspecialidades.Registrar(1, "Cardiología");
var medico = servicioMedicos.Registrar(1, "Luis", "Gómez", "luis@clinica.com", "8095559999");
servicioMedicos.AsignarEspecialidad(medico, cardiologia);

var paciente = servicioPacientes.Registrar(1, "Ana", "Pérez", "ana@correo.com", "8095551234");

var cita = servicioCitas.Agendar(1, paciente, medico, DateTime.Now.AddDays(1));
Console.WriteLine(cita.EstaProgramada());

servicioRecordatorios.EnviarRecordatorio(cita);

servicioCitas.Reprogramar(cita.Id, DateTime.Now.AddDays(2));
Console.WriteLine(cita.FechaHora);

servicioCitas.Cancelar(cita.Id);
Console.WriteLine(cita.EstaCancelada());

Console.WriteLine();
Console.WriteLine("--- Pacientes registrados ---");
foreach (var p in servicioPacientes.ObtenerTodos())
{
    Console.WriteLine(p.MostrarDetalles());
}

Console.WriteLine();
Console.WriteLine("--- Médicos registrados ---");
foreach (var m in servicioMedicos.ObtenerTodos())
{
    Console.WriteLine(m.MostrarDetalles());
}

Console.WriteLine();
Console.WriteLine("--- Especialidades registradas ---");
foreach (var e in servicioEspecialidades.ObtenerTodas())
{
    Console.WriteLine(e.Nombre);
}

Console.WriteLine();
Console.WriteLine("--- Citas del paciente Ana ---");
foreach (var c in servicioCitas.PorPaciente(paciente.ID))
{
    Console.WriteLine($"Cita el {c.FechaHora} - Estado: {c.Estado}");
}

Console.WriteLine();
Console.WriteLine("--- Citas del médico Luis ---");
foreach (var c in servicioCitas.PorMedico(medico.ID))
{
    Console.WriteLine($"Cita el {c.FechaHora} - Estado: {c.Estado}");
}   