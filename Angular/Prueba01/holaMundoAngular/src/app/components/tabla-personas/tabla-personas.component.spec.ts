import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TablaPersonasComponent } from './tabla-personas.component';

describe('TablaPersonasComponent', () => {
  let component: TablaPersonasComponent;
  let fixture: ComponentFixture<TablaPersonasComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TablaPersonasComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TablaPersonasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
