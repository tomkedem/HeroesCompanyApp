import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NotFoundComponent } from './Errors/not-found/not-found.component';
import { ServerErrorComponent } from './Errors/server-error/server-error.component';
import { TestErrorsComponent } from './Errors/test-errors/test-errors.component';
import { AllHeroesListComponent } from './heroes/all-heroes-list/all-heroes-list.component';
import { HeroListComponent } from './heroes/hero-list/hero-list.component';
import { HomeComponent } from './home/home.component';
import { TrainerListComponent } from './trainers/trainer-list/trainer-list.component';
import { AuthGuard } from './_guards/auth.guard';

const routes: Routes = [
  {path: '', component: HomeComponent},
  {
    path: '',
    runGuardsAndResolvers: 'always',
    canActivate: [AuthGuard],
    children:[
      {path: 'trainers', component: TrainerListComponent, canActivate: [AuthGuard]},
      {path: 'heroesList', component: AllHeroesListComponent},
      {path: 'heroes', component: HeroListComponent},
    ]
  },
  {path: 'errors', component: TestErrorsComponent},
  {path: 'not-found', component: NotFoundComponent},
  {path: 'server-error', component: ServerErrorComponent},
  {path: '**', component: HomeComponent, pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
