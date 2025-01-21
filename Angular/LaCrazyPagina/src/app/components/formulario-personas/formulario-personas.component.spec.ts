import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FormularioPersonasComponent } from './formulario-personas.component';

describe('FormularioPersonasComponent', () => {
  let component: FormularioPersonasComponent;
  let fixture: ComponentFixture<FormularioPersonasComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FormularioPersonasComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FormularioPersonasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
