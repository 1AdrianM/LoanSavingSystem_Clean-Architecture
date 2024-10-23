import { Injectable } from '@angular/core';
import { Cliente } from '../../Models/cliente';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ClienteService {

  URL:string;
  PORT:number=58631;

  constructor(private readonly http : HttpClient) {
    this.URL = `http://localhost:${this.PORT}/api/clients`;
   }


CreateCliente(cliente:Cliente){
    return this.http.post<Cliente>(`${this.URL}/create`, cliente)
   }
GetClients(){
    return this.http.get<Cliente>(`${this.URL}/get/clientlist`)

   }
UpdateClients(client:Cliente, id:number){
  return this.http.put<Cliente>(`${this.URL}/update/${id}`, client)

}
GetClientById(id:number){
  return this.http.get<Cliente>(`${this.URL}/get/${id}`)

}
DeleteClient(id:number){
  return this.http.delete<Cliente>(`${this.URL}/delete/${id}`)
}

}
