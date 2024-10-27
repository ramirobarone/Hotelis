import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BodyPrincipalComponent } from './body-principal.component';

describe('BodyPrincipalComponent', () => {
  let component: BodyPrincipalComponent;
  let fixture: ComponentFixture<BodyPrincipalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BodyPrincipalComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BodyPrincipalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
