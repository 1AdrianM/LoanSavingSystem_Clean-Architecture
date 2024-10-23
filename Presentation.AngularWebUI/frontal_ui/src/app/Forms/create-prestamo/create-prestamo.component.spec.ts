import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreatePrestamoComponent } from './create-prestamo.component';

describe('CreatePrestamoComponent', () => {
  let component: CreatePrestamoComponent;
  let fixture: ComponentFixture<CreatePrestamoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CreatePrestamoComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CreatePrestamoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
