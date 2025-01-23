import { Component } from '@angular/core';
import { Router, RouterLink, RouterLinkActive } from '@angular/router';

@Component({
  selector: 'app-tabla-personas',
  imports: [RouterLink, RouterLinkActive],
  templateUrl: './tabla-personas.component.html',
  styleUrl: './tabla-personas.component.css'
})
export class TablaPersonasComponent {
  constructor(private router: Router){ }
   Listado():void{
    this.router.navigate(['/listado']);
  }
}
