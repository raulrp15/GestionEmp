import { AfterViewInit, Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Persona } from '../../interfaces/persona';
import { PersonasService } from '../../services/persona.service';
import { DatePipe, NgFor } from '@angular/common';
import { MatIconModule } from '@angular/material/icon';
import { MatBottomSheet, MatBottomSheetRef } from '@angular/material/bottom-sheet';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { ViewChild } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialog, MatDialogActions, MatDialogClose, MatDialogContent, MatDialogRef, MatDialogTitle, MatDialogModule } from '@angular/material/dialog';
import { MatListModule } from '@angular/material/list';

//#region Tabla
@Component({
  selector: 'app-tabla-api',
  standalone: true,
  imports: [NgFor, DatePipe, MatIconModule, MatPaginatorModule, MatTableModule],
  templateUrl: './tabla-api.component.html',
  styleUrl: './tabla-api.component.css'
})
export class TablaApiComponent implements OnInit, AfterViewInit 
{
  listadoPersonas = new MatTableDataSource<Persona>([]);
  displayedColumns: string[] = ['id', 'nombre', 'apellidos', 'fechaNacimiento'];
  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(
    private personasServicio: PersonasService,
    private _bottomSheet: MatBottomSheet,
  ) {}

  ngOnInit(): void {
    this.obtenerPersonas();
  }

  ngAfterViewInit() {
    this.listadoPersonas.paginator = this.paginator;
  }
  async obtenerPersonas() {
    this.personasServicio.getPersonas().subscribe({
      next: (response) => {
        this.listadoPersonas.data = response;
        this.listadoPersonas.paginator = this.paginator;
      },
      error: () => {
        alert("Ha ocurrido un error al obtener los datos del servidor");
      }
    });
  }
  openBottomSheet(personaId: number): void {
    const bottomSheetRef = this._bottomSheet.open(OptionsComponent);
    bottomSheetRef.instance.personaId = personaId;
    bottomSheetRef.instance.deleteConfirmed.subscribe((confirmed: boolean) => {
      if (confirmed) {
        this.eliminarPersona(personaId);  // Llama a la función para eliminar
      }
    });
  }

  eliminarPersona(id: number): void {
    this.personasServicio.delPersonas(id).subscribe({
      next: (response) => {
        alert(response + " filas afectadas");
        this.obtenerPersonas();  // Recarga la lista de personas
      },
      error: () => {
        alert("Ha ocurrido un error al eliminar la persona");
      }
    });
  }
}
//#endregion

//#region Opciones
@Component({
  selector: 'app-options',
  imports: [MatListModule],
  templateUrl: './options.component.html',
})
export class OptionsComponent {
  @Input() personaId: number; // Recibe el ID de la persona que se va a eliminar
  @Output() deleteConfirmed = new EventEmitter<boolean>(); // Emite un evento cuando se confirme o no

  constructor(
    private _bottomSheetRef: MatBottomSheetRef<OptionsComponent>,
    private dialog: MatDialog
  ) {}

  deletePersona(): void {
    const dialogRef = this.dialog.open(DialogoComponent);

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        // Si el usuario confirma, emite el evento de confirmación
        this.deleteConfirmed.emit(true);
        this._bottomSheetRef.dismiss(); // Cierra el bottom sheet
      } else {
        // Si el usuario cancela
        this.deleteConfirmed.emit(false);
        this._bottomSheetRef.dismiss(); // Cierra el bottom sheet
      }
    });
  }
}
//#endregion

//#region Dialogo Delete
@Component({
  selector: 'app-dialogo',
  imports: [
    MatDialogTitle,
    MatDialogContent,
    MatDialogActions,
  ],
  templateUrl: './dialogo.component.html',
})
export class DialogoComponent {
  constructor(public dialogRef: MatDialogRef<DialogoComponent>) {}

  onConfirm(): void {
    this.dialogRef.close(true);
  }

  onCancel(): void {
    this.dialogRef.close(false);
  }
}
//#endregion