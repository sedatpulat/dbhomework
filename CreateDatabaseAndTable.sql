
CREATE DATABASE sfntdesu 
WITH 
   ENCODING = 'UTF8'
   OWNER = sfntdesu
   CONNECTION LIMIT = 100;


CREATE SCHEMA public AUTHORIZATION postgres;

CREATE TABLE public.accidents (
	accidentid int NOT NULL GENERATED ALWAYS AS IDENTITY( INCREMENT BY 1 MINVALUE 1 MAXVALUE 2147483647 START 1 CACHE 1 NO CYCLE),
	"date" date NULL,
	description varchar NULL,
	damageamount numeric NULL,
	"Location" varchar NULL,
	carid int NULL
);


CREATE TABLE public.car (
	carid int NOT NULL GENERATED ALWAYS AS IDENTITY( INCREMENT BY 1 MINVALUE 1 MAXVALUE 2147483647 START 1 CACHE 1 NO CYCLE),
	model varchar NULL,
	brand varchar NULL,
	"year" varchar NULL,
	submodel varchar NULL,
	engineno varchar NULL,
	color varchar NULL,
	plate varchar NULL,
	customerid int NULL
);


CREATE TABLE public.customer (
	customerid int NOT NULL GENERATED ALWAYS AS IDENTITY( INCREMENT BY 1 MINVALUE 1 MAXVALUE 2147483647 START 1 CACHE 1 NO CYCLE),
	"name" varchar NULL,
	surname varchar NULL,
	address varchar NULL,
	dateofbirth date NULL,
	email varchar NULL,
	phone varchar NULL,
	gender varchar NULL
);


CREATE TABLE public.insurancepolicy (
	policyid int NOT NULL GENERATED ALWAYS AS IDENTITY( INCREMENT BY 1 MINVALUE 1 MAXVALUE 2147483647 START 1 CACHE 1 NO CYCLE),
	policynumber varchar NULL,
	policystartdate date NULL,
	policyenddate date NULL,
	totalcovargeamount numeric NULL,
	carid int NULL,
	covargetype varchar NULL
);


CREATE TABLE public.premiumpayment (
	paymentid int NOT NULL GENERATED ALWAYS AS IDENTITY( INCREMENT BY 1 MINVALUE 1 MAXVALUE 2147483647 START 1 CACHE 1 NO CYCLE),
	amount numeric NULL,
	paymentdate date NULL,
	duedate date NULL,
	paymentmethod varchar NULL,
	policyid int NULL
);
