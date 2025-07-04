﻿using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using NuGet.Common;
using System.Net.Http.Headers;

namespace MVC.Controllers
{
    public class ControllerB : Controller
    {

        public string? urlBase;

        public ResHttpViewModel WebApi_Process(string url, object? obj=null, string httpVerb="GET")
        {
            HttpClient cliente = new HttpClient();
            Task<HttpResponseMessage> tarea;

            if (httpVerb == "GET")
            {
                tarea = cliente.GetAsync(url);
            }
            else if (httpVerb == "POST")
            {
                tarea = cliente.PostAsJsonAsync(url, obj);
            }
            else if (httpVerb == "PUT")
            {
                tarea = cliente.PutAsJsonAsync(url, obj);
            }
            else if (httpVerb == "DELETE")
            {
                tarea = cliente.DeleteAsync(url);
            }
            else
            {
                throw new Exception("Debe seleccionar un verbo HTTP indicado");
            }
            HttpResponseMessage respuesta = tarea.Result;

            HttpContent contenido = respuesta.Content;
            Task<string> body = contenido.ReadAsStringAsync();
            body.Wait();
            string datos = body.Result;

            ResHttpViewModel res = new()
            {
                Respuesta = respuesta,
                Datos = datos
            };

            return res;
        }

        public ResHttpViewModel WebApi_Process_WithAuthentication(string url, object? obj = null, string httpVerb = "GET")
        {
            HttpClient cliente = new HttpClient();

                cliente.DefaultRequestHeaders.Authorization = 
                    new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("Token"));

            Task<HttpResponseMessage> tarea;

            if (httpVerb == "GET")
            {
                tarea = cliente.GetAsync(url);
            }
            else if (httpVerb == "POST")
            {
                tarea = cliente.PostAsJsonAsync(url, obj);
            }
            else if (httpVerb == "PUT")
            {
                tarea = cliente.PutAsJsonAsync(url, obj);
            }
            else if (httpVerb == "DELETE")
            {
                tarea = cliente.DeleteAsync(url);
            }
            else
            {
                throw new Exception("Debe seleccionar un verbo HTTP indicado");
            }
            HttpResponseMessage respuesta = tarea.Result;

            HttpContent contenido = respuesta.Content;
            Task<string> body = contenido.ReadAsStringAsync();
            body.Wait();
            string datos = body.Result;

            ResHttpViewModel res = new()
            {
                Respuesta = respuesta,
                Datos = datos
            };

            return res;
        }
    }
}