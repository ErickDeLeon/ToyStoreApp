import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, NgForm, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { Toys } from 'src/app/shared/toys.model';
import { ToysService } from 'src/app/shared/toys.service';
import Swal from 'sweetalert2'

@Component({
  selector: 'app-toys-form',
  templateUrl: './toys-form.component.html',
  styles: [
  ]
})
export class ToysFormComponent implements OnInit {

  form = new FormGroup({
    restriccionEdad: new FormControl('', Validators.required)
  }) // Instantiating our form

  constructor(public service: ToysService,
    private toastr:ToastrService,
    ) { 

    }

  ngOnInit(): void {

  }


  onSubmit(form:NgForm){

    var jso = form.value;
    
    var result = Object.keys(jso).map(e => jso[e]);

    if(result[2] < 0 || result[2] > 100)
    {
      Swal.fire('La edad no puede ser ' + result[2] + ' años')
      return
    } 

    if(result[4] < 1 || result[4] > 1000)
    {
      Swal.fire('El precio tiene que ser entre $1 y $1,000')
      return
    } 

    if(this.service.formData.id == 0){
      this.insertRecord(form);
    }   
    else{
      console.log('update')
      this.updateRecord(form);
    }

  }

  insertRecord(form: NgForm){
    this.service.postToys().subscribe(
      res => {
        this.resetForm(form);
        this.toastr.success('Se agrego Correctamente', 'Juguete registrado');
        this.service.refreshList();
      },
      err => {console.log(err)}
    );
  }

  updateRecord(form: NgForm){
    this.service.putToys().subscribe(
      res => {
        this.resetForm(form);
        this.toastr.info('Se actualizó Correctamente', 'Juguete actualizado');
        this.service.refreshList();
      },
      err => {console.log(err)}
    );
  }

  resetForm(form: NgForm){
    form.form.reset();
    this.service.formData = new Toys();
  }

  OnlyNumbersAllowed(event: { which: any; }):boolean{

    const charCode = (event.which)? event.which: event

    if(charCode > 31 && (charCode < 48 || charCode > 57))
    {
      return false;
    }
    return true;
  }
}
