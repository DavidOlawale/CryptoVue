import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-base',
  template: '',
  styles: [
  ]
})
export class BaseComponent implements OnInit {

  constructor(private baseToastr: ToastrService) { }

  ngOnInit(): void {
  }

  showMessage(type :'success'| 'error' , message: string, title: string ) {
    if(type == 'success'){
      this.baseToastr.success(message, title);
    }
    
    if(type == 'error'){
      this.baseToastr.error(message, title);
    }
    
    } 
}