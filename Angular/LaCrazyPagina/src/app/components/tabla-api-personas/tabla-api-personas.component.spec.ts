import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TablaApiPersonasComponent } from './tabla-api-personas.component';

describe('TablaApiPersonasComponent', () => {
  let component: TablaApiPersonasComponent;
  let fixture: ComponentFixture<TablaApiPersonasComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TablaApiPersonasComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TablaApiPersonasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
