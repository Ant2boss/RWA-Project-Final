use AdventureWorksOBP
go

/*
----------------------
	PROCEDURES
----------------------
*/

/*
----------------------
	KUPAC
----------------------
*/

create proc RWA_AK_GetAllKupac
as
begin
	select * from Kupac
end
go

create proc RWA_AK_GetKupac @IDKupac int
as
begin
	select * from Kupac
		where IDKupac = @IDKupac
end
go

create proc RWA_AK_CreateKupac @Ime nvarchar(50), @Prezime nvarchar(50), @Email nvarchar(50), @Telefon nvarchar(25), @GradID int
as
begin
	insert into Kupac values (@Ime, @Prezime, @Email, @Telefon, @GradID)
end
go

create proc RWA_AK_UpdateKupac @IDKupac int, @Ime nvarchar(50), @Prezime nvarchar(50), @Email nvarchar(50), @Telefon nvarchar(25), @GradID int
as
begin
	update Kupac set
		Ime = @Ime,
		Prezime = @Prezime,
		Email = @Email,
		Telefon = @Telefon,
		GradID = @GradID
		where IDKupac = @IDKupac
end
go

create proc RWA_AK_DeleteKupac @IDKupac int
as
begin
	delete from Kupac
		where IDKupac = @IDKupac
end
go

/*
----------------------
	GRAD
----------------------
*/

create proc RWA_AK_GetAllGrad
as
begin
	select * from Grad
end
go

create proc RWA_AK_GetGradoviOfDrzava @IDDrzava int
as
begin
	select * from Grad as G
		inner join Drzava as D on D.IDDrzava = G.DrzavaID
		where D.IDDrzava = @IDDrzava
end
go

create proc RWA_AK_GetGrad @IDGrad int
as
begin
	select * from Grad	
		where IDGrad = @IDGrad
end
go

create proc RWA_AK_CreateGrad @Naziv nvarchar(50), @DrzavaID int
as
begin
	insert into Grad values (@Naziv, @DrzavaID)
end
go

create proc RWA_AK_UpdateGrad @IDGrad int, @Naziv nvarchar(50), @DrzavaID int
as
begin
	update Grad set
		Naziv = @Naziv,
		DrzavaID = @DrzavaID
		where IDGrad = @IDGrad
end
go

create proc RWA_AK_DeleteGrad @IDGrad int
as
begin
	delete from Grad
		where IDGrad = @IDGrad
end
go

/*
----------------------
	DRZAVA
----------------------
*/

create proc RWA_AK_GetAllDrzava
as
begin
	select * from Drzava
end
go

create proc RWA_AK_GetDrzava @IDDrzava int
as
begin	
	select * from Drzava
		where IDDrzava = @IDDrzava
end
go

create proc RWA_AK_CreateDrzava @Naziv nvarchar(50)
as
begin
	insert into Drzava values (@Naziv)
end
go

create proc RWA_AK_UpdateDrzava @IDDrzava int, @Naziv nvarchar(50)
as
begin
	update Drzava set Naziv = @Naziv where IDDrzava = @IDDrzava
end
go

create proc RWA_AK_DeleteDrzava @IDDrzava int
as
begin
	delete from Drzava where IDDrzava = @IDDrzava
end
go

/*
----------------------
	PROIZVOD
----------------------
*/

create proc RWA_AK_GetAllProizvod
as
begin
	select * from Proizvod
end
go

create proc RWA_AK_GetProizvod @IDProizvod int
as
begin
	select * from Proizvod
		where IDProizvod = @IDProizvod
end
go

create proc RWA_AK_CreateProizvod @Naziv nvarchar(50), @BrojProizvoda nvarchar(25), @Boja nvarchar(15), @MinimalnaKolicina smallint, @CijenaBezPDV money, @PotkategorijaID int
as
begin
	if(@PotkategorijaID = 0)
	begin
		insert into Proizvod(Naziv, BrojProizvoda, Boja, MinimalnaKolicinaNaSkladistu, CijenaBezPDV) values (@Naziv, @BrojProizvoda, @Boja, @MinimalnaKolicina, @CijenaBezPDV)
	end
	else
	begin
		insert into Proizvod values (@Naziv, @BrojProizvoda, @Boja, @MinimalnaKolicina, @CijenaBezPDV, @PotkategorijaID)
	end
end
go

create proc RWA_AK_UpdateProizvod @IDProizvod int, @Naziv nvarchar(50), @BrojProizvoda nvarchar(25), @Boja nvarchar(15), @MinimalnaKolicina smallint, @CijenaBezPDV money, @PotkategorijaID int
as
begin
	if(@PotkategorijaID = 0)
	begin
		set @PotkategorijaID = null
	end

	update Proizvod set
		Naziv = @Naziv,
		BrojProizvoda = @BrojProizvoda,
		Boja = @Boja,
		MinimalnaKolicinaNaSkladistu = @MinimalnaKolicina,
		CijenaBezPDV = @CijenaBezPDV,
		PotkategorijaID = @PotkategorijaID
		where IDProizvod = @IDProizvod
end
go

create proc RWA_AK_DeleteProizvod @IDProizvod int
as
begin
	delete from Proizvod
		where IDProizvod = @IDProizvod
end
go

/*
----------------------
	POTKATEGORIJA
----------------------
*/

create proc RWA_AK_GetAllPotkategorija
as
begin
	select * from Potkategorija
end
go

create proc RWA_AK_GetPotkategorija @IDPotkategorija int
as
begin
	select * from Potkategorija
		where IDPotkategorija = @IDPotkategorija
end
go

create proc RWA_AK_CreatePotkategorija @Naziv nvarchar(50), @KategorijaID int
as
begin
	insert into Potkategorija values (@KategorijaID, @Naziv)
end
go

create proc RWA_AK_UpdatePotkategorija @IDPotkategorija int, @Naziv nvarchar(50), @KategorijaID int
as
begin
	update Potkategorija set
		Naziv = @Naziv,
		KategorijaID = @KategorijaID
		where IDPotkategorija = @IDPotkategorija
end
go

create proc RWA_AK_DeletePotkategorija @IDPotkategorija int
as
begin
	delete from Potkategorija
		where IDPotkategorija = @IDPotkategorija
end
go

/*
----------------------
	KATEGORIJA
----------------------
*/

create proc RWA_AK_GetAllKategorija
as
begin
	select * from Kategorija
end
go

create proc RWA_AK_GetKategorija @IDKategorija int
as
begin
	 select * from Kategorija
		where IDKategorija = @IDKategorija
end
go

create proc RWA_AK_CreateKategorija @Naziv nvarchar(50)
as
begin
	insert into Kategorija values (@Naziv)
end
go

create proc RWA_AK_UpdateKategorija @IDKategorija int, @Naziv nvarchar(50)
as
begin
	update Kategorija set
		Naziv = @Naziv
		where IDKategorija = @IDKategorija
end
go

create proc RWA_AK_DeleteKategorija @IDKategorija int
as
begin
	delete from Kategorija
		where IDKategorija = @IDKategorija		
end
go

/*
----------------------
	KOMERCIJALIST
----------------------
*/

create proc RWA_AK_GetAllKomercijalist
as
begin
	select * from Komercijalist
end
go

create proc RWA_AK_GetKomercijalist @IDKomercijalist int
as
begin
	select * from Komercijalist
		where IDKomercijalist = @IDKomercijalist
end
go

create proc RWA_AK_CreateKomercijalist @Ime nvarchar(50), @Prezime nvarchar(50), @StalniZaposlenik bit
as
begin
	insert into Komercijalist values (@Ime, @Prezime, @StalniZaposlenik)
end
go

create proc RWA_AK_UpdateKomercijalist @IDKomercijalist int, @Ime nvarchar(50), @Prezime nvarchar(50), @StalniZaposlenik bit
as
begin
	update Komercijalist set
		Ime = @Ime,
		Prezime = @Prezime,
		StalniZaposlenik = @StalniZaposlenik
		where IDKomercijalist = @IDKomercijalist
end
go

create proc RWA_AK_DeleteKomercijalist @IDKomercijalist int
as
begin
	delete from Komercijalist
		where IDKomercijalist = @IDKomercijalist
end
go


/*
----------------------
	KREDITNA KARTICA
----------------------
*/

create proc RWA_AK_GetAllKreditnaKartica
as
begin
	select * from KreditnaKartica
end
go

create proc RWA_AK_GetKreditnaKartica @IDKreditnaKartica int
as
begin
	select * from KreditnaKartica
		where IDKreditnaKartica = @IDKreditnaKartica
end
go

create proc RWA_AK_CreateKreditnaKartica @Tip nvarchar(50), @Broj nvarchar(25), @IstekMjesec tinyint, @IstekGodina smallint
as
begin
	insert into KreditnaKartica values(@Tip, @Broj, @IstekMjesec, @IstekGodina)
end
go

create proc RWA_AK_UpdateKreditnaKartica @IDKreditnaKartica int, @Tip nvarchar(50), @Broj nvarchar(25), @IstekMjesec tinyint, @IstekGodina smallint
as
begin
	update KreditnaKartica set
		Tip = @Tip,
		Broj = @Broj,
		IstekMjesec = @IstekMjesec,
		IstekGodina = @IstekGodina
		where IDKreditnaKartica = @IDKreditnaKartica
end
go

create proc RWA_AK_DeleteKreditnaKartica @IDKreditnaKartica int
as
begin
	delete from KreditnaKartica
		where IDKreditnaKartica = @IDKreditnaKartica
end
go


/*
----------------------
	RACUN
----------------------
*/

create proc RWA_AK_GetAllRacun
as
begin
	select * from Racun
end
go

create proc RWA_AK_GetRacun @IDRacun int
as
begin
	select * from Racun
		where IDRacun = @IDRacun
end
go

create proc RWA_AK_CreateRacun @DatumIzdavanja datetime, @BrojRacuna nvarchar(25), @KupacID int, @KomercijalistID int, @KreditnaKarticaID int, @Komentar nvarchar(128)
as
begin
	insert into Racun values (@DatumIzdavanja, @BrojRacuna, @KupacID, @KomercijalistID, @KreditnaKarticaID, @Komentar)
end
go

create proc RWA_AK_UpdateRacun @IDRacun int, @DatumIzdavanja datetime, @BrojRacuna nvarchar(25), @KupacID int, @KomercijalistID int, @KreditnaKarticaID int, @Komentar nvarchar(128)
as
begin
	update Racun set
		DatumIzdavanja = @DatumIzdavanja,
		BrojRacuna = @BrojRacuna,
		KupacID = @KupacID,
		KomercijalistID = @KomercijalistID,
		KreditnaKarticaID = @KreditnaKarticaID,
		Komentar = @Komentar
end
go

create proc RWA_AK_DeleteRacun @IDRacun int
as
begin
	delete from Racun
		where IDRacun = @IDRacun
end
go

create proc RWA_AK_GetRacuniOfKupac @IDKupac int
as
begin
	select * from Racun
		where KupacID = @IDKupac
end
go

/*
----------------------
	STAVKA
----------------------
*/

create proc RWA_AK_GetAllStavka
as
begin
	select * from Stavka
end
go

create proc RWA_AK_GetStavka @IDStavka int
as
begin
	select * from Stavka
		where IDStavka = @IDStavka
end
go

create proc RWA_AK_CreateStavka @RacunID int, @Kolicina smallint, @ProizvodID int, @CijenaPoKomadu money, @Popust money, @UkupnaCijena numeric(38, 6)
as
begin
	insert into Stavka values(@RacunID, @Kolicina, @ProizvodID, @CijenaPoKomadu, @Popust, @UkupnaCijena)
end
go

create proc RWA_AK_UpdateStavka @IDStavka int, @RacunID int, @Kolicina smallint, @ProizvodID int, @CijenaPoKomadu money, @Popust money, @UkupnaCijena numeric(38, 6)
as
begin
	update Stavka set
		RacunID = @RacunID,
		Kolicina = @Kolicina,
		ProizvodID = @ProizvodID,
		CijenaPoKomadu = @CijenaPoKomadu,
		PopustUPostocima = @Popust,
		UkupnaCijena = @UkupnaCijena
end
go

create proc RWA_AK_DeleteStavka @IDStavka int
as
begin
	delete from Stavka where IDStavka = @IDStavka
end
go

create proc RWA_AK_GetStavkeOfRacun @IDRacun int
as
begin
	select * from Stavka
		where RacunID = @IDRacun
end
go