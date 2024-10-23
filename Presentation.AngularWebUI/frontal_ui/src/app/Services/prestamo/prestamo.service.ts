import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Prestamo } from '../../Models/prestamo';
import { Cliente } from '../../Models/cliente';

@Injectable({
  providedIn: 'root'
})
export class PrestamoService {

  URL:string;
  PORT:number=58631;

  constructor(private readonly http : HttpClient) {
    this.URL = `http://localhost:${this.PORT}/api/prestamos`;
   }

   CreatePrestamo(prestamo:Prestamo){
return this.http.post<Cliente>(`${this.URL}/create`, prestamo)
   }
   UpdatePrestamo(){

   }
   GetPrestamoById(){

   }
   DeletePrestamo(){

   }
   ApprovePrestamo(){
    
   }
}
