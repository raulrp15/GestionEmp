import { Component, OnInit } from '@angular/core';
import { RouterLink, RouterLinkActive } from '@angular/router';
import { ReactiveFormsModule, Validators } from '@angular/forms';
import { FormGroup, FormControl } from '@angular/forms';
import { NgIf } from '@angular/common';

@Component({
  selector: 'app-formulario-personas',
  imports: [RouterLink, RouterLinkActive, ReactiveFormsModule, NgIf],
  templateUrl: './formulario-personas.component.html',
  styleUrl: './formulario-personas.component.css'
})
export class FormularioPersonasComponent implements OnInit{
  
  formulario:FormGroup

  constructor(){}
  ngOnInit(): void {
    this.formulario = new FormGroup({
      nombre: new FormControl('',[Validators.required]),
      apellidos:new FormControl('',[Validators.required]),
    })
  }
  saluda(){
    if(this.formulario.valid){
      alert('Hola ' + this.formulario.controls.nombre.value + ' ' + this.formulario.controls.apellidos.value);
    }
  }
}
