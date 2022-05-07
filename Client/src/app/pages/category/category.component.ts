import { Component, OnInit } from '@angular/core';
import { HttpService } from 'src/app/services/http.services';
import { NgxSpinnerService } from 'ngx-spinner';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.scss']
})
export class CategoryComponent implements OnInit {

  jokesCategories:Array<any> = [];
  categoryJokeDetails:any = {}

  constructor(
    private service:HttpService,
    private spinner:NgxSpinnerService
  ) { }

  ngOnInit(): void {
    this.spinner.show();
    this.service.getCategories().subscribe((categories)=>{
      if(categories.succeeded)
        this.jokesCategories = categories?.data
      this.spinner.hide();
    }, error => { 
      alert(`${error.error.error}`);
      this.spinner.hide();
    });
  }

  getCatgoryJoke(category:string){
    this.spinner.show()
    this.service.getCategoryDetails(category).subscribe((response)=>{
      if(response.succeeded)
        this.categoryJokeDetails = response.data; 
      this.spinner.hide()
    }, error => { 
      alert(`${error.error.error}`);
      this.spinner.hide();
    });
  }

}
