--
-- PostgreSQL database dump
--

-- Dumped from database version 16.3
-- Dumped by pg_dump version 16.3 (Homebrew)

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- Name: journey; Type: DATABASE; Schema: -; Owner: postgres
--

CREATE DATABASE journey WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'en_US.UTF-8';


ALTER DATABASE journey OWNER TO postgres;

\connect journey

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: Activities; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Activities" (
    "Id" uuid NOT NULL,
    "Name" text,
    "Date" timestamp without time zone,
    "Status" integer,
    "TripId" uuid
);


ALTER TABLE public."Activities" OWNER TO postgres;

--
-- Name: Trips; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Trips" (
    "Id" uuid NOT NULL,
    "Name" text,
    "StartDate" timestamp without time zone,
    "EndDate" timestamp without time zone
);


ALTER TABLE public."Trips" OWNER TO postgres;

--
-- Data for Name: Activities; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Activities" ("Id", "Name", "Date", "Status", "TripId") FROM stdin;
2b34c4e8-5678-4d3a-a2be-2c9e9f1e34c7	Passeio no Louvre	2024-07-04 14:00:00	0	3fa85f64-5717-4562-b3fc-2c963f66afa6
7e98a6e3-6389-426e-9bdb-476b3fa3df9e	Passeio em Copacabana	2024-09-08 14:00:00	0	b1d5c254-97e4-4b7a-b5f7-bfd7fdf4ea6a
9b04ef5c-7bfc-4a71-931e-74dcb9cb9a69	Cruzamento no Rio Sena	2024-07-06 12:00:00	0	3fa85f64-5717-4562-b3fc-2c963f66afa6
9c2f8b3e-76a9-4234-9d3f-2378c3e7d42a	Visita a Montreal	2024-10-15 11:00:00	0	fb3fc2e7-c714-4e2a-98e1-8f40cb24d3b2
a34d33ef-8941-4f72-912c-58a67e3b74df	Visita a Tokyo Tower	2024-08-16 09:00:00	0	7b9c61ae-3ef8-48b1-94a8-896e5fb90895
a3d7b6e2-9e1a-4b8e-9b3f-7e2c1d8f2e4e	Passeio em Veneza	2025-01-18 10:00:00	0	e6d9b9f3-b15e-4a36-bb65-69e3d3fd76e4
af48c733-0f2d-4e3b-b547-d7f4c3c5a32a	Excursão a Vancouver	2024-10-17 10:00:00	0	fb3fc2e7-c714-4e2a-98e1-8f40cb24d3b2
b2f6c3e8-4f1b-4c5d-8f3e-1e2c1d8f3e7c	Visita ao Vaticano	2025-01-20 11:00:00	0	e6d9b9f3-b15e-4a36-bb65-69e3d3fd76e4
b9d4e7e3-7f6b-4b4a-9d2b-6e2c1d8f1e2e	Passeio em Cape Town	2024-12-06 09:00:00	0	d5f1b3e9-bfb7-4d7f-a6a8-c5d3bde920ec
bfe7e9e1-334b-4c1f-9f4d-d2b8d69f2a33	Passeio na Grande Barreira de Coral	2024-11-04 12:00:00	0	a7bb7c50-0f04-4af6-9635-48c6b539e2e7
c1a72b74-9b5b-4e9c-8f32-63914c8d8355	Passeio em Toronto	2024-10-13 13:00:00	0	fb3fc2e7-c714-4e2a-98e1-8f40cb24d3b2
c3e7b9a4-9c3d-4f81-9a7b-8e3f7d3a6f9e	Visita à Table Mountain	2024-12-04 11:00:00	0	d5f1b3e9-bfb7-4d7f-a6a8-c5d3bde920ec
c4e7b9f1-8f3a-4d7e-9f2c-5e1c3d7f9e4a	Tour pela Toscana	2025-01-22 13:00:00	0	e6d9b9f3-b15e-4a36-bb65-69e3d3fd76e4
c87d96fe-4857-44d9-8f23-d3f2e5473f82	Visita às Cataratas do Niágara	2024-10-11 09:00:00	0	fb3fc2e7-c714-4e2a-98e1-8f40cb24d3b2
cbac3b2a-7fb6-4b91-9332-b9cf5b70f1d3	Excursão a Hiroshima	2024-08-22 08:00:00	0	7b9c61ae-3ef8-48b1-94a8-896e5fb90895
d02a15f6-7d2c-4d8c-96d4-5e6a34b0e933	Visita ao Cristo Redentor	2024-09-06 09:00:00	0	b1d5c254-97e4-4b7a-b5f7-bfd7fdf4ea6a
d5c3e9fb-8c8b-4f91-926b-9f27b5aaf9f1	Visita à Opera House	2024-11-02 09:00:00	0	a7bb7c50-0f04-4af6-9635-48c6b539e2e7
e1a1df1e-1cbb-4c2b-989e-501a333d33e2	Visita à Torre Eiffel	2024-07-02 10:00:00	0	3fa85f64-5717-4562-b3fc-2c963f66afa6
e1d3a6fe-1b4f-4b5b-8f35-9e3a5c8d1e6c	Safári no Kruger National Park	2024-12-02 06:00:00	0	d5f1b3e9-bfb7-4d7f-a6a8-c5d3bde920ec
e4b8a1f6-7f84-4b6a-b1a9-8c9e2d1c4f8e	Visita ao Parque Nacional de Kakadu	2024-11-06 08:00:00	0	a7bb7c50-0f04-4af6-9635-48c6b539e2e7
e8b3c5d9-4f1a-4b6e-9f4c-2e1c9d5e1e7a	Visita ao Coliseu	2025-01-16 09:00:00	0	e6d9b9f3-b15e-4a36-bb65-69e3d3fd76e4
e91bdc6f-9e92-4f7b-97df-8d3c02c9c8f1	Visita a Kyoto	2024-08-20 10:00:00	0	7b9c61ae-3ef8-48b1-94a8-896e5fb90895
f1c8a6de-3e7b-4980-8a2d-24b944b75567	Passeio em Shibuya	2024-08-18 15:00:00	0	7b9c61ae-3ef8-48b1-94a8-896e5fb90895
f2e1c9d3-9f1a-4d4b-9b8c-3f2d1e9c4f7b	Visita à Robben Island	2024-12-08 12:00:00	0	d5f1b3e9-bfb7-4d7f-a6a8-c5d3bde920ec
f53cb0c4-5e9f-4f30-9a76-0348c328dbf8	Visita a Montmartre	2024-07-08 11:00:00	0	3fa85f64-5717-4562-b3fc-2c963f66afa6
f73d5a15-3a5c-493e-a1b3-5b8f9457e2e7	Visita ao Pão de Açúcar	2024-09-10 10:00:00	0	b1d5c254-97e4-4b7a-b5f7-bfd7fdf4ea6a
f89b34a1-0a14-4f52-a9f1-3f0c4e3347d7	Visita ao Monte Fuji	2024-08-24 13:00:00	0	7b9c61ae-3ef8-48b1-94a8-896e5fb90895
dbbcf2d2-c0e3-49f5-b5ef-1061fd7f75da	ACTIVITY from local to aws rds	2024-07-16 00:42:12.692	0	02a01dbc-b008-41e8-a281-3a92570da2f2
70a3f27b-10d8-4ca9-8b6c-78f21da9eba1	Visitar loja da Nintendo	2024-08-16 00:44:17.476	0	7b9c61ae-3ef8-48b1-94a8-896e5fb90895
1b620f43-7552-4a97-9ade-4cab5b0991f2	Cafézinho perto da Eiffel	2024-07-09 03:03:49.342	0	3fa85f64-5717-4562-b3fc-2c963f66afa6
076ccab3-14e7-4ae9-8d31-cc5457d631c3	Box com Cangurus	2024-11-06 03:06:21.821	1	a7bb7c50-0f04-4af6-9635-48c6b539e2e7
\.


--
-- Data for Name: Trips; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Trips" ("Id", "Name", "StartDate", "EndDate") FROM stdin;
3fa85f64-5717-4562-b3fc-2c963f66afa6	Viagem a Paris	2024-07-01 00:00:00	2024-07-10 23:59:59
7b9c61ae-3ef8-48b1-94a8-896e5fb90895	Viagem ao Japão	2024-08-15 00:00:00	2024-08-25 23:59:59
a7bb7c50-0f04-4af6-9635-48c6b539e2e7	Viagem à Austrália	2024-11-01 00:00:00	2024-11-11 23:59:59
b1d5c254-97e4-4b7a-b5f7-bfd7fdf4ea6a	Viagem ao Brasil	2024-09-05 00:00:00	2024-09-15 23:59:59
d5f1b3e9-bfb7-4d7f-a6a8-c5d3bde920ec	Viagem à África do Sul	2024-12-01 00:00:00	2024-12-10 23:59:59
e6d9b9f3-b15e-4a36-bb65-69e3d3fd76e4	Viagem à Itália	2025-01-15 00:00:00	2025-01-25 23:59:59
fb3fc2e7-c714-4e2a-98e1-8f40cb24d3b2	Viagem ao Canadá	2024-10-10 00:00:00	2024-10-20 23:59:59
02a01dbc-b008-41e8-a281-3a92570da2f2	New trip from local to aws	2024-07-15 20:47:25.997	2024-08-15 20:47:25.997
7394423a-be5e-45c5-9f82-dd8cf01949d9	New trip from k8s LOCAL	2024-07-16 00:17:27.65	2024-08-16 00:17:27.65
\.


--
-- Name: Activities activities_pk; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Activities"
    ADD CONSTRAINT activities_pk PRIMARY KEY ("Id");


--
-- Name: Trips trips_pk; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Trips"
    ADD CONSTRAINT trips_pk PRIMARY KEY ("Id");


--
-- Name: Activities activities_trips_id_fk; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Activities"
    ADD CONSTRAINT activities_trips_id_fk FOREIGN KEY ("TripId") REFERENCES public."Trips"("Id");


--
-- PostgreSQL database dump complete
--

