using System;

[Serializable()]
public enum RoleType { None, Admin, Mentor, Mentee }

[Serializable()]
public enum CrudType { None, Create, Read, Update, Delete }

[Serializable()]
public enum ConnectionStatus { None = 0, /* Rejected = -1 ,*/ Pending = 1, Accepted = 2 }