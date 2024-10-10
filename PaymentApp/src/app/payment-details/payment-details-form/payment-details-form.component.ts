import { Component } from '@angular/core';
import { PaymentDetailService } from '../../shared/payment-detail.service';
import { NgForm } from '@angular/forms';
import { PaymentDetail } from '../../shared/payment-detail.model';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-payment-details-form',
  templateUrl: './payment-details-form.component.html',
  styles: ``
})

export class PaymentDetailsFormComponent {

  constructor(public service:PaymentDetailService,private toastr:ToastrService){

  }

  onSubmit(form:NgForm){
    this.service.formSubmitted = true;

    if (form.valid) {
      if (this.service.formData.paymentDetailsId === 0) {
        this.insertRecord(form); // Inserting new record
      } else {
        console.log(this.service.formData.paymentDetailsId); // Debugging if ID exists
        this.updateRecord(form); // Updating existing record
      }
    }

  }
  insertRecord(form:NgForm){
    this.service.postPaymentDetail()
    .subscribe({
      next:res=>{
        this.service.list=res as PaymentDetail[];
        this.service.resetForm(form)
        this.toastr.success('inserted successfully','payment detail register')
      },
      error:err=>{console.log(err)}
    })
  }
  updateRecord(form: NgForm) {
    console.log('Updating record with ID:', this.service.formData);  // Debugging
    if (this.service.formData.paymentDetailsId) {
      this.service.putPaymentDetail().subscribe({
        next: res => {
          this.service.list = res as PaymentDetail[];
          this.service.resetForm(form);
          this.toastr.info('Updated successfully', 'Payment detail register');
        },
        error: err => {
          console.log(err);
        }
      });
    } else {
      console.error('Error: paymentDetailId is undefined.');
    }
  }

}
