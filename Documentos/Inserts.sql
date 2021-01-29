INSERT INTO Issue ([Classification],[Status],[ReportDate],[ResolutionComment],[SupervisorId],[ServiceId],[CreateBy],[CreateDate]) values
('Media','Ingresado', GETDATE(),'No sirve mi internet',3,1,65, GETDATE()),
('Baja','Asignado', GETDATE(),'No puedo ver mis novelas',3,2,87, GETDATE()),
('Alta','En Progreso', GETDATE(),'Mi celular no sirve',3,4,23, GETDATE());


INSERT INTO Service([Name], CreateBy, CreateDate) values('Internet',3,GETDATE()),('Cable',3,GETDATE()),('Telefonia',3,GETDATE()),('Telefonia Movil',3,GETDATE());