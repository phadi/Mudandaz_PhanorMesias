
export interface User {
  userId: number;
  name: string;
  login: string;
  password: string;
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
