export interface Prestamo {
    prestatarioId:number;
fiadorId:number;
garantiaId:number;
fechaSolicitud:Date;
monto:number;
}
export interface UpdatePrestamo{
    prestamoId:number;
prestatarioId:number;
fiadorId	:number;
garantia	:number;
codigoPrestamo	:string;
fechaSolicitud:Date;
fechaAprobacion	:Date;
fechaInicio:Date;	
fechaTermino:Date;	
monto:number;
interes:number;	

}