// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Statement.Create.Table;

public class ColDataTypeTest {
internal virtual void testPublicType() {
string sqlStr = "select 1::public.integer";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

internal virtual void testIssue1879() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("CREATE TABLE public.film (\n", "    film_id integer DEFAULT nextval('public.film_film_id_seq'::regclass) NOT NULL,\n"), "    title character varying(255) NOT NULL,\n"), "    description text,\n"), "    release_year public.year,\n"), "    language_id smallint NOT NULL,\n"), "    rental_duration smallint DEFAULT 3 NOT NULL,\n"), "    rental_rate numeric(4,2) DEFAULT 4.99 NOT NULL,\n"), "    length smallint,\n"), "    replacement_cost numeric(5,2) DEFAULT 19.99 NOT NULL,\n"), "    rating public.mpaa_rating DEFAULT 'G'::public.mpaa_rating,\n"), "    last_update timestamp without time zone DEFAULT now() NOT NULL,\n"), "    special_features text[],\n"), "    fulltext tsvector NOT NULL\n"), ")");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

public virtual void testNestedCast() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT acolumn::bit(64)::int(64) FROM mytable");
}

[Xunit.Fact]
public void __Upstream_656d59df0a375adf()
{
        try
        {
            this.testIssue1879();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_91a929babb4fa7d1()
{
        try
        {
            this.testNestedCast();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_c0cfa5dbe840b35c()
{
        try
        {
            this.testPublicType();
        }
        finally
        {
        }
}
}
