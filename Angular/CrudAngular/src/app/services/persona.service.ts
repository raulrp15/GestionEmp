import { inject, Injectable } from '@angular/core';

import { HttpClient } from '@angular/common/http';

import { Observable } from 'rxjs';

import { Persona } from '../interfaces/persona';
import { ObserversModule } from '@angular/cdk/observers';

@Injectable(
  {
    providedIn: 'root'
  }
)

export class PersonasService 
{
  urlWebAPI='https://raulcrudapi.azurewebsites.net/api/personaapi';
  constructor() { }
  http=inject(HttpClient);
  getPersonas(): Observable<Persona[]>
  {
    return this.http.get<Persona[]>(this.urlWebAPI);
  }
  delPersonas(id:number){
    return this.http.delete(this.urlWebAPI+"/"+id);
  }
  insPersona(persona:Persona): Observable<number>{
    return this.http.post<number>(this.urlWebAPI,persona);
  }
  updPersona(persona:Persona): Observable<number>{
    return this.http.put<number>(this.urlWebAPI+"/"+persona.id,persona);
  }
}