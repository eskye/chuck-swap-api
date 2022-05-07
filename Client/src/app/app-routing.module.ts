import { NgModule } from "@angular/core";
import { RouterModule, Routes } from '@angular/router';
import { IndexComponent } from "./pages/index/index.component";

const routes:Routes = [
   {
      path:'',
      pathMatch:'full',
      loadChildren:()=> import('./pages/index/index.module').then((m)=>m.IndexModule)
   },
   {
      path:'joke',
      loadChildren:()=> import('./pages/category/category.module').then((m)=>m.CategoryModule)
   },
   {
      path:'people',
      loadChildren:()=> import('./pages/people/people.module').then((m)=>m.PeopleModule)
   },
]

@NgModule({
   imports: [RouterModule.forRoot(routes)],
   exports: [RouterModule]
})
export class AppRoutingModule{}