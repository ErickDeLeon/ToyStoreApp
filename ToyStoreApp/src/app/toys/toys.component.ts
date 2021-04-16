import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Toys } from '../shared/toys.model';
import { ToysService  } from '../shared/toys.service';
import Swal from 'sweetalert2'


@Component({
  selector: 'app-toys',
  templateUrl: './toys.component.html',
  styles: [
  ]
})
export class ToysComponent implements OnInit {

  constructor(public service: ToysService, 
    private toastr:ToastrService) { }

  ngOnInit(): void {
    this.service.refreshList();
  }

  populateForm(selectedRecord: Toys){
    console.log(selectedRecord);
    this.service.formData = Object.assign({}, selectedRecord);
    console.log(Object.assign({}, selectedRecord));
  }

  onDelete(id:number){
    Swal.fire({
      title: '¿Está seguro?',
      text: '¡No podrá recuperar este registro!',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonText: 'Si',
      cancelButtonText: 'No'
    }).then((result) =>{
      if(result.value){

        this.service.deleteToy(id).subscribe(
          res => {
            this.service.refreshList();
            this.toastr.error("Se eliminó correctamente", 'Juego Eliminado');
    
          },
          err => {console.log(err)}
        );
      } 
    }); 
  }


}
