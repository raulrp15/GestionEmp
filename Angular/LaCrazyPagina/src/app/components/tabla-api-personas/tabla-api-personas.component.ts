import { Component, OnInit } from '@angular/core';
import { Persona } from '../../interfaces/persona';
import { PersonasService } from '../../services/personas.service';
import { NgFor, CommonModule } from '@angular/common';
import {MatDialogModule} from '@angular/material/dialog';

@Component({
  selector: 'app-tabla-api-personas',
  imports: [NgFor, CommonModule, MatDialogModule],
  templateUrl: './tabla-api-personas.component.html',
  styleUrl: './tabla-api-personas.component.css'
})
export class TablaApiPersonasComponent implements OnInit{
  listadoPersonas:Persona[];

  constructor(private personasServicio: PersonasService) { }
  
  ngOnInit(): void {
  
  this.obtenerPersonas();
}
async obtenerPersonas() {

  this.personasServicio.getPersonas().subscribe({
  
  next:(response) =>{
  
  this.listadoPersonas=response;
  
  },
  
  error: (error)=>{
  
  alert("Ha ocurrido un error al obtener los datos del servidor");
  
  }
  
  });
  
  }

async eliminarPersona(id: number){
  
  this.personasServicio.deletePersona(id).subscribe({
  
  next:(response) => {
  
  
  
  this.obtenerPersonas();
  
  },
  
  error: (error) => {
  
  alert("Ha ocurrido un error al eliminar la persona");
  }
  
  });
}
}