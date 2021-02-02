
export interface User {
  userId: number;
  name: string;
  login: string;
  password: string;
}

export class UserEdited {
  UserId: number;
  Name: string;
  Login: string;
  Password: string;
}

export interface Module {
  moduleId: number;
  module: string;
  description: string;
  url: string;
  image: string;
}

export interface UserModules {
  user: User;
  modules: Module[];
}

export interface TrazaEjecucion {
  trazaEjecucionId: number;
  dateTime: Date;
  ejecutorId: string;
  userId: number;
  observations: string;
  login: string;
  dateStr: string;
}

export class TrazaEjecucionModel {
  TrazaEjecucionId: number;
  DateTime: Date;
  EjecutorId: string;
  UserId: number;
  Observations: string;
}
