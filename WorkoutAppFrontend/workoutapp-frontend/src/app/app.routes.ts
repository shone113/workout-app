import { Routes } from '@angular/router';
import { LoginComponent } from './features/login/login';
import { RegisterComponent } from './features/register/register';
import { WorkoutCalendar } from './features/workout-calendar/workout-calendar';

export const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'workout-calendar', component: WorkoutCalendar},
  { path: '', redirectTo: 'login', pathMatch: 'full' }
];
