import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HeroDetailComponent } from './heroes/hero-detail/hero-detail.component';
import { HeroListComponent } from './heroes/hero-list/hero-list.component';
import { HomeComponent } from './home/home.component';
import { InstructorDetailComponent } from './instructors/instructor-detail/instructor-detail.component';
import { InstructorListComponent } from './instructors/instructor-list/instructor-list.component';
import { ListsComponent } from './lists/lists.component';
import { MessagesComponent } from './messages/messages.component';
import { AuthGuard } from './_guards/auth.guard';

const routes: Routes = [
  {path: '', component: HomeComponent},
  {
    path: '',
    runGuardsAndResolvers: 'always',
    canActivate: [AuthGuard],
    children:[
      {path: 'instructors', component: InstructorListComponent, canActivate: [AuthGuard]},
      {path: 'instructor/:id', component: InstructorDetailComponent},
      {path: 'heroes', component: HeroListComponent},
      {path: 'hero/:id', component: HeroDetailComponent},
      {path: 'lists', component: ListsComponent},
      {path: 'messages', component: MessagesComponent},
      {path: '**', component: HomeComponent, pathMatch: 'full'}
    ]

  },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
