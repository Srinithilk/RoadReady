import { Component } from '@angular/core';
import { CustomerService } from '../../../Services/customer.service';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-update-profile',
  templateUrl: './update-profile.component.html',
  styleUrl: './update-profile.component.css'
})
export class UpdateProfileComponent {
  customer: any = {};
  
  constructor(private service: CustomerService, private router: Router,private toastr: ToastrService) {
    this.getProfileByUserId();
  }

  getProfileByUserId() {
    debugger;
    this.service.getProfileByUserId().subscribe((res)=>{
      this.customer = res; 
        console.log(this.customer);
    },err=>{
      alert("Error: " + err);
      console.log(err);
    });
  }
  get passwordsMismatch(): boolean {
    return this.customer.Password !== this.customer.RePassword;
}
  updateProfile() {
    debugger;
    this.service.updateProfileByUserId(this.customer).subscribe((res) => {
      console.log(res);
      //alert("Profile Updated Successfully");
      //console.log(this.toastr.success('Password reset successful', 'Success'));
      this.router.navigateByUrl("/customer/profile/showProfile");
      this.toastr.success('Profile Updated successfully', 'Success')

    },err=>{
      alert("Error: " + err);
      console.log(err);
    });
  }
}
