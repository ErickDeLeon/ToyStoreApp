import { Component, OnInit } from '@angular/core';
import { FormControl, NgForm, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { Toys } from 'src/app/shared/toys.model';
import { ToysService } from 'src/app/shared/toys.service';

@Component({
  selector: 'app-toys-form',
  templateUrl: './toys-form.component.html',
  styles: [
  ]
})
export class ToysFormComponent implements OnInit {

  constructor(public service: ToysService,
    private toastr:ToastrService

    ) { }

  ngOnInit(): void {

  }

  onSubmit(form:NgForm){

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
      console.log('El codigo es ' + charCode);
      return false;
    }
    return true;
  }

  onSearchChange(evento: any) : boolean{
    
    const input = evento.target.value;
    var myFloat = parseFloat(input);

    if( myFloat < 1 ){
      console.log('Menor de 1')
      return false;
    }

    console.log(input)

    return true;
  }

}
