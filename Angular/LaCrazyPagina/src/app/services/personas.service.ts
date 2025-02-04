import { inject, Injectable } from '@angular/core';

import { HttpClient, HttpParams } from '@angular/common/http';

import { Observable } from 'rxjs';

import { Persona } from '../interfaces/persona';

@Injectable({

providedIn: 'root'

})

export class PersonasService {

urlWebAPI='https://raulcrudapi.azurewebsites.net/api/personaapi';

constructor() { }

http=inject(HttpClient);

getPersonas(): Observable<Persona[]>{

return this.http.get<Persona[]>(this.urlWebAPI);

}

deletePersona(id: number){
    return this.http.delete(this.urlWebAPI + '/' + id);
}

}
