import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WorkoutCalendar } from './workout-calendar';

describe('WorkoutCalendar', () => {
  let component: WorkoutCalendar;
  let fixture: ComponentFixture<WorkoutCalendar>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [WorkoutCalendar]
    })
    .compileComponents();

    fixture = TestBed.createComponent(WorkoutCalendar);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
