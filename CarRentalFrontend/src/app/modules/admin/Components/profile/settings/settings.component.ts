import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { StorageService } from 'src/app/auth/Services/storage/storage.service';
import { AdminService } from '../../../Services/admin.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-settings',
  templateUrl: './settings.component.html',
  styleUrl: './settings.component.css'
})
export class SettingsComponent {
  admin: any;
  enteredPassword: string = '';
  confirmPassword: string = '';
  constructor(private service: AdminService, private router: Router,private toastr: ToastrService) {
    this.getProfileByAdminId();
  }
  
  confirmDelete() {
    debugger;
    if (this.enteredPassword.trim() === '') {
      this.toastr.error("Please Enter Password", 'Error');
      return;
    }
    
    if (this.enteredPassword === this.confirmPassword) {
      this.service.deleteProfileByUserId(this.admin).subscribe(
        (res) => {
          console.log(res);
          this.router.navigateByUrl('/login');
          this.toastr.success('Password Deleted Successfully', 'Success');
        },
        (err) => {
          console.log('Error: ' + err);
          this.toastr.error('Failed to delete profile. Please try again later.', 'Error');
        }
      );
    } else {
      this.toastr.error('Incorrect password. Please try again.', 'Error');
    }
  }

  getProfileByAdminId() {
    debugger;
    this.service.getProfileByAdminId().subscribe((res) => {
      this.admin = res;
      console.log(this.admin);
      this.confirmPassword = this.admin.Password;
    }, err => {
      alert("Error: " + err);
      console.log(err);
    });
  }



  cancelDelete() {
    this.router.navigateByUrl('/admin/profile/showProfile');
  }


}
