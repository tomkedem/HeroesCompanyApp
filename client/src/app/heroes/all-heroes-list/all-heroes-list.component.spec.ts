import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AllHeroesListComponent } from './all-heroes-list.component';

describe('AllHeroesListComponent', () => {
  let component: AllHeroesListComponent;
  let fixture: ComponentFixture<AllHeroesListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AllHeroesListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AllHeroesListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
