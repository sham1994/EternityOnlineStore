import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { AuthService } from '../_services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
})
export class RegisterComponent implements OnInit {
  @Input() valuesFromHome: any;
  @Output() cancelRegister = new EventEmitter();
  //outupt property emits events
  model: any = {};
  currentdate = new Date();

  constructor(private authService: AuthService) {}

  ngOnInit() {}
  register() {
    this.model.created = this.currentdate;
    this.authService.register(this.model).subscribe(
      () => {
        console.log('Registration successful');
      },
      (error) => {
        console.log(error);
      }
    );
  }
  cancel() {
    this.cancelRegister.emit(false);
    //.emit = because we are emiting something from this method
    console.log('Cancelled');
  }
}
