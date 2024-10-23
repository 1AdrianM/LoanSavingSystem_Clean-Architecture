import { Component } from '@angular/core';
import { Cliente } from '../../Models/cliente';
import { ClienteService } from '../../Services/cliente/cliente.service';

@Component({
  selector: 'app-create-cliente',
  standalone: true,
  imports: [],
  templateUrl: './create-cliente.component.html',
  styleUrl: './create-cliente.component.css'
})
export class CreateClienteComponent {

  client :Cliente = {
    cedula: '',
    nombre: '',
    apellidos: '',
    email: '',
    telefono: 0,
    tipoCliente: '',
    street: '',
    city: '',
    state: '',
    country: ''
  }
  constructor(private readonly clienteService: ClienteService) {}

onSubmit():void{
  this.clienteService.CreateCliente(this.client).subscribe((response: any) => {
    console.log('Cliente creado:', response);
  }, (error: any) => {
    console.error('Error al crear el cliente:', error);
  });
}
}
