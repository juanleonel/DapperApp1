﻿
namespace DapperApp.Querys
{
    public static class QuerysClass
    {

       public static string SQL_One_to_one_Person = @"SELECT 'Daniel Dennett' AS Name, 
                                                            1942 AS Born, 
                                                            'United States of America' AS  Residence
                                                    UNION ALL 
                                                   SELECT 'Sam Harris' AS Name, 
                                                           1967 AS Born, 
                                                          'United States of America' AS Residence
                                                    UNION ALL 
                                                   SELECT 'Richard Dawkins' AS Name, 
                                                           1941 AS Born, 
                                                          'United Kingdom' AS Residence";

        public static string SQL_One_to_many_Person = @"SELECT 1 AS Id, 'Daniel Dennett' AS Name, 1942 AS Born, 1 AS
                        CountryId, 'United States of America' AS CountryName, 1 AS BookId, 'Brainstorms' AS BookName
                        UNION ALL SELECT 1 AS Id, 'Daniel Dennett' AS Name, 1942 AS Born, 1 AS CountryId, 'United
                        States of America' AS CountryName, 2 AS BookId, 'Elbow Room' AS BookName
                        UNION ALL SELECT 2 AS Id, 'Sam Harris' AS Name, 1967 AS Born, 1 AS CountryId, 'United States
                        of America' AS CountryName, 3 AS BookId, 'The Moral Landscape' AS BookName
                        UNION ALL SELECT 2 AS Id, 'Sam Harris' AS Name, 1967 AS Born, 1 AS CountryId, 'United States
                        of America' AS CountryName, 4 AS BookId, 'Waking Up: A Guide to Spirituality Without Religion'
                        AS BookName
                        UNION ALL SELECT 3 AS Id, 'Richard Dawkins' AS Name, 1941 AS Born, 2 AS CountryId, 'United
                        Kingdom' AS CountryName, 5 AS BookId, 'The Magic of Reality: How We Know What`s Really True'
                        AS BookName
                        UNION ALL SELECT 3 AS Id, 'Richard Dawkins' AS Name, 1941 AS Born, 2 AS CountryId, 'United
                        Kingdom' AS CountryName, 6 AS BookId, 'An Appetite for Wonder: The Making of a Scientist' AS
                        BookName";
    }
}
