SET IDENTITY_INSERT [dbo].[Envios] ON
INSERT INTO [dbo].[Envios] ([Id], [NumeroTracking], [PesoPaquete], [Estado], [ClienteId], [FuncionarioId], [Discriminator], [AgenciaId], [DireccionPostal], [EntregaEficiente]) VALUES (61, N'12441', 12, 0, 2, 1, N'Comun', 1, NULL, NULL)
INSERT INTO [dbo].[Envios] ([Id], [NumeroTracking], [PesoPaquete], [Estado], [ClienteId], [FuncionarioId], [Discriminator], [AgenciaId], [DireccionPostal], [EntregaEficiente]) VALUES (62, N'124413', 12, 0, 2, 1, N'Comun', 1, NULL, NULL)
INSERT INTO [dbo].[Envios] ([Id], [NumeroTracking], [PesoPaquete], [Estado], [ClienteId], [FuncionarioId], [Discriminator], [AgenciaId], [DireccionPostal], [EntregaEficiente]) VALUES (63, N'6234325', 12, 0, 2, 1, N'Urgente', NULL, 11900, 0)
SET IDENTITY_INSERT [dbo].[Envios] OFF
