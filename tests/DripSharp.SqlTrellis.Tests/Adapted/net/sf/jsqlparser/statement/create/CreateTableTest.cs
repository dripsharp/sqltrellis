// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Statement.Create;

public class CreateTableTest {
private readonly global::DripSharp.SqlTrellis.Parser.CCJSqlParserManager parserManager = new global::DripSharp.SqlTrellis.Parser.CCJSqlParserManager();

public virtual void testCreateTableOrReplace() {
string statement = "CREATE OR REPLACE TABLE testtab (\"test\" varchar (255))";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement);
}

public virtual void testCreateTable2() {
string statement = "CREATE TABLE testtab (\"test\" varchar (255))";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement);
}

public virtual void testCreateTable3() {
string statement = "CREATE TABLE testtab (\"test\" varchar (255), \"test2\" varchar (255))";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement);
}

public virtual void testCreateTableAsSelect() {
string statement = "CREATE TABLE a AS SELECT col1, col2 FROM b";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement);
}

public virtual void testCreateTableAsSelect2() {
string statement = "CREATE TABLE newtable AS WITH a AS (SELECT col1, col3 FROM testtable) SELECT col1, col2, col3 FROM b INNER JOIN a ON b.col1 = a.col1";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement);
}

public virtual void testCreateTable() {
string statement = global::DripSharp.Runtime.JavaCompat.Concat("CREATE TABLE mytab (mycol a (10, 20) c nm g, mycol2 mypar1 mypar2 (23,323,3) asdf ('23','123') dasd, ", "PRIMARY KEY (mycol2, mycol)) type = myisam");
global::DripSharp.SqlTrellis.Statement.Create.Table.CreateTable createTable = (global::DripSharp.SqlTrellis.Statement.Create.Table.CreateTable)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
global::DripSharp.Testing.JavaAssertions.Equal(2, global::DripSharp.Runtime.JavaCompat.CollectionCount(createTable.getColumnDefinitions()), null);
global::DripSharp.Testing.JavaAssertions.False(createTable.isUnlogged(), null);
global::DripSharp.Testing.JavaAssertions.Equal("mycol", global::DripSharp.Runtime.JavaCompat.ListGet(createTable.getColumnDefinitions(), 0).getColumnName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("mycol2", global::DripSharp.Runtime.JavaCompat.ListGet(createTable.getColumnDefinitions(), 1).getColumnName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("PRIMARY KEY", global::DripSharp.Runtime.JavaCompat.ListGet(createTable.getIndexes(), 0).getType(), null);
global::DripSharp.Testing.JavaAssertions.Equal("mycol", global::DripSharp.Runtime.JavaCompat.ListGet(global::DripSharp.Runtime.JavaCompat.ListGet(createTable.getIndexes(), 0).getColumnsNames(), 1), null);
global::DripSharp.Testing.JavaAssertions.Equal(statement, global::DripSharp.Runtime.JavaCompat.Concat("", createTable), null);
}

public virtual void testCreateTableUnlogged() {
string statement = global::DripSharp.Runtime.JavaCompat.Concat("CREATE UNLOGGED TABLE mytab (mycol a (10, 20) c nm g, mycol2 mypar1 mypar2 (23,323,3) asdf ('23','123') dasd, ", "PRIMARY KEY (mycol2, mycol)) type = myisam");
global::DripSharp.SqlTrellis.Statement.Create.Table.CreateTable createTable = (global::DripSharp.SqlTrellis.Statement.Create.Table.CreateTable)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
global::DripSharp.Testing.JavaAssertions.Equal(2, global::DripSharp.Runtime.JavaCompat.CollectionCount(createTable.getColumnDefinitions()), null);
global::DripSharp.Testing.JavaAssertions.True(createTable.isUnlogged(), null);
global::DripSharp.Testing.JavaAssertions.Equal("mycol", global::DripSharp.Runtime.JavaCompat.ListGet(createTable.getColumnDefinitions(), 0).getColumnName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("mycol2", global::DripSharp.Runtime.JavaCompat.ListGet(createTable.getColumnDefinitions(), 1).getColumnName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("PRIMARY KEY", global::DripSharp.Runtime.JavaCompat.ListGet(createTable.getIndexes(), 0).getType(), null);
global::DripSharp.Testing.JavaAssertions.Equal("mycol", global::DripSharp.Runtime.JavaCompat.ListGet(global::DripSharp.Runtime.JavaCompat.ListGet(createTable.getIndexes(), 0).getColumnsNames(), 1), null);
global::DripSharp.Testing.JavaAssertions.Equal(statement, global::DripSharp.Runtime.JavaCompat.Concat("", createTable), null);
}

public virtual void testCreateTableUnlogged2() {
string statement = "CREATE UNLOGGED TABLE mytab (mycol a (10, 20) c nm g, mycol2 mypar1 mypar2 (23,323,3) asdf ('23','123') dasd, PRIMARY KEY (mycol2, mycol))";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement);
}

public virtual void testCreateTableForeignKey() {
string statement = "CREATE TABLE test (id INT UNSIGNED NOT NULL AUTO_INCREMENT, string VARCHAR (20), user_id INT UNSIGNED, PRIMARY KEY (id), FOREIGN KEY (user_id) REFERENCES ra_user(id))";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement);
}

public virtual void testCreateTableForeignKey2() {
string statement = "CREATE TABLE test (id INT UNSIGNED NOT NULL AUTO_INCREMENT, string VARCHAR (20), user_id INT UNSIGNED, PRIMARY KEY (id), CONSTRAINT fkIdx FOREIGN KEY (user_id) REFERENCES ra_user(id))";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement);
}

public virtual void testCreateTableForeignKey3() {
string statement = "CREATE TABLE test (id INT UNSIGNED NOT NULL AUTO_INCREMENT, string VARCHAR (20), user_id INT UNSIGNED REFERENCES ra_user(id), PRIMARY KEY (id))";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement, true);
}

public virtual void testCreateTableForeignKey4() {
string statement = "CREATE TABLE test (id INT UNSIGNED NOT NULL AUTO_INCREMENT, string VARCHAR (20), user_id INT UNSIGNED FOREIGN KEY REFERENCES ra_user(id), PRIMARY KEY (id))";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement, true);
}

public virtual void testCreateTablePrimaryKey() {
string statement = "CREATE TABLE test (id INT UNSIGNED NOT NULL AUTO_INCREMENT, string VARCHAR (20), user_id INT UNSIGNED, CONSTRAINT pk_name PRIMARY KEY (id))";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement);
}

public virtual void testCreateTableParams() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("CREATE TEMPORARY TABLE T1 (PROCESSID VARCHAR (32)) ON COMMIT PRESERVE ROWS");
}

public virtual void testCreateTableParams2() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("CREATE TEMPORARY TABLE t1 WITH (APPENDONLY=true,ORIENTATION=column,COMPRESSTYPE=zlib,OIDS=FALSE) ON COMMIT DROP AS SELECT column FROM t2");
}

public virtual void testCreateTableUniqueConstraint() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("CREATE TABLE Activities (", "_id INTEGER PRIMARY KEY AUTOINCREMENT"), ",uuid VARCHAR(255)"), ",user_id INTEGER"), ",sound_id INTEGER"), ",sound_type INTEGER"), ",comment_id INTEGER"), ",type String,tags VARCHAR(255)"), ",created_at INTEGER"), ",content_id INTEGER"), ",sharing_note_text VARCHAR(255)"), ",sharing_note_created_at INTEGER"), ",UNIQUE (created_at, type, content_id, sound_id, user_id)"), ")");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
global::DripSharp.Testing.JavaAssertions.True((global::DripSharp.Runtime.JavaCompat.ListGet(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parseStatements(sqlStr).getStatements(), 0) is global::DripSharp.SqlTrellis.Statement.Create.Table.CreateTable), null);
}

public virtual void testCreateTableUniqueConstraintAfterPrimaryKey() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("-- UniqueConstraintAfterPrimaryKey\n", "CREATE TABLE employees (\n"), "    employee_number    int         NOT NULL\n"), "    , employee_name    char (50)   NOT NULL\n"), "    , department_id    int\n"), "    , salary           int\n"), "    , PRIMARY KEY (employee_number)\n"), "    , UNIQUE (employee_name)\n"), "    , FOREIGN KEY (department_id)\n"), "        REFERENCES departments(department_id)\n"), "  ) parallel compress nologging");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
global::DripSharp.SqlTrellis.Statement.Create.Table.CreateTable createTable = (global::DripSharp.SqlTrellis.Statement.Create.Table.CreateTable)(global::DripSharp.Runtime.JavaCompat.ListGet(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parseStatements(sqlStr).getStatements(), 0)!);
global::DripSharp.Testing.JavaAssertions.Equal("PRIMARY KEY", global::DripSharp.Runtime.JavaCompat.ListGet(createTable.getIndexes(), 0).getType(), null);
global::DripSharp.Testing.JavaAssertions.Equal("UNIQUE", global::DripSharp.Runtime.JavaCompat.ListGet(createTable.getIndexes(), 1).getType(), null);
global::DripSharp.Testing.JavaAssertions.Equal("FOREIGN KEY", global::DripSharp.Runtime.JavaCompat.ListGet(createTable.getIndexes(), 2).getType(), null);
}

public virtual void testCreateTableDefault() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("CREATE TABLE T1 (id integer default -1)");
}

public virtual void testCreateTableDefault2() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("CREATE TABLE T1 (id integer default 1)");
}

public virtual void testCreateTableIfNotExists() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("CREATE TABLE IF NOT EXISTS animals (id INT NOT NULL)");
}

public virtual void testCreateTableInlinePrimaryKey() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("CREATE TABLE animals (id INT PRIMARY KEY NOT NULL)");
}

public virtual void testCreateTableWithRange() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("CREATE TABLE foo (name character varying (255), range character varying (255), start_range integer, end_range integer)");
}

public virtual void testCreateTableWithKey() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("CREATE TABLE bar (key character varying (255) NOT NULL)");
}

public virtual void testCreateTableWithUniqueKey() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("CREATE TABLE animals (id INT NOT NULL, name VARCHAR (100) UNIQUE KEY (id))");
}

public virtual void testCreateTableVeryComplex() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("CREATE TABLE `wp_commentmeta` ( `meta_id` bigint(20) unsigned NOT NULL AUTO_INCREMENT, `comment_id` bigint(20) unsigned NOT NULL DEFAULT '0', `meta_key` varchar(255) DEFAULT NULL, `meta_value` longtext, PRIMARY KEY (`meta_id`), KEY `comment_id` (`comment_id`), KEY `meta_key` (`meta_key`) ) ENGINE=InnoDB DEFAULT CHARSET=utf8", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("CREATE TABLE `wp_comments` ( `comment_ID` bigint(20) unsigned NOT NULL AUTO_INCREMENT, `comment_post_ID` bigint(20) unsigned NOT NULL DEFAULT '0', `comment_author` tinytext NOT NULL, `comment_author_email` varchar(100) NOT NULL DEFAULT '', `comment_author_url` varchar(200) NOT NULL DEFAULT '', `comment_author_IP` varchar(100) NOT NULL DEFAULT '', `comment_date` datetime NOT NULL DEFAULT '0000-00-00 00:00:00', `comment_date_gmt` datetime NOT NULL DEFAULT '0000-00-00 00:00:00', `comment_content` text NOT NULL, `comment_karma` int(11) NOT NULL DEFAULT '0', `comment_approved` varchar(20) NOT NULL DEFAULT '1', `comment_agent` varchar(255) NOT NULL DEFAULT '', `comment_type` varchar(20) NOT NULL DEFAULT '', `comment_parent` bigint(20) unsigned NOT NULL DEFAULT '0', `user_id` bigint(20) unsigned NOT NULL DEFAULT '0', PRIMARY KEY (`comment_ID`), KEY `comment_post_ID` (`comment_post_ID`), KEY `comment_approved_date_gmt` (`comment_approved`,`comment_date_gmt`), KEY `comment_date_gmt` (`comment_date_gmt`), KEY `comment_parent` (`comment_parent`) ) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("CREATE TABLE `wp_links` ( `link_id` bigint(20) unsigned NOT NULL AUTO_INCREMENT, `link_url` varchar(255) NOT NULL DEFAULT '', `link_name` varchar(255) NOT NULL DEFAULT '', `link_image` varchar(255) NOT NULL DEFAULT '', `link_target` varchar(25) NOT NULL DEFAULT '', `link_description` varchar(255) NOT NULL DEFAULT '', `link_visible` varchar(20) NOT NULL DEFAULT 'Y', `link_owner` bigint(20) unsigned NOT NULL DEFAULT '1', `link_rating` int(11) NOT NULL DEFAULT '0', `link_updated` datetime NOT NULL DEFAULT '0000-00-00 00:00:00', `link_rel` varchar(255) NOT NULL DEFAULT '', `link_notes` mediumtext NOT NULL, `link_rss` varchar(255) NOT NULL DEFAULT '', PRIMARY KEY (`link_id`), KEY `link_visible` (`link_visible`) ) ENGINE=InnoDB DEFAULT CHARSET=utf8", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("CREATE TABLE `wp_options` ( `option_id` bigint(20) unsigned NOT NULL AUTO_INCREMENT, `option_name` varchar(64) NOT NULL DEFAULT '', `option_value` longtext NOT NULL, `autoload` varchar(20) NOT NULL DEFAULT 'yes', PRIMARY KEY (`option_id`), UNIQUE KEY `option_name` (`option_name`) ) ENGINE=InnoDB AUTO_INCREMENT=402 DEFAULT CHARSET=utf8", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("CREATE TABLE `wp_postmeta` ( `meta_id` bigint(20) unsigned NOT NULL AUTO_INCREMENT, `post_id` bigint(20) unsigned NOT NULL DEFAULT '0', `meta_key` varchar(255) DEFAULT NULL, `meta_value` longtext, PRIMARY KEY (`meta_id`), KEY `post_id` (`post_id`), KEY `meta_key` (`meta_key`) ) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("CREATE TABLE `wp_posts` ( `ID` bigint(20) unsigned NOT NULL AUTO_INCREMENT, `post_author` bigint(20) unsigned NOT NULL DEFAULT '0', `post_date` datetime NOT NULL DEFAULT '0000-00-00 00:00:00', `post_date_gmt` datetime NOT NULL DEFAULT '0000-00-00 00:00:00', `post_content` longtext NOT NULL, `post_title` text NOT NULL, `post_excerpt` text NOT NULL, `post_status` varchar(20) NOT NULL DEFAULT 'publish', `comment_status` varchar(20) NOT NULL DEFAULT 'open', `ping_status` varchar(20) NOT NULL DEFAULT 'open', `post_password` varchar(20) NOT NULL DEFAULT '', `post_name` varchar(200) NOT NULL DEFAULT '', `to_ping` text NOT NULL, `pinged` text NOT NULL, `post_modified` datetime NOT NULL DEFAULT '0000-00-00 00:00:00', `post_modified_gmt` datetime NOT NULL DEFAULT '0000-00-00 00:00:00', `post_content_filtered` longtext NOT NULL, `post_parent` bigint(20) unsigned NOT NULL DEFAULT '0', `guid` varchar(255) NOT NULL DEFAULT '', `menu_order` int(11) NOT NULL DEFAULT '0', `post_type` varchar(20) NOT NULL DEFAULT 'post', `post_mime_type` varchar(100) NOT NULL DEFAULT '', `comment_count` bigint(20) NOT NULL DEFAULT '0', PRIMARY KEY (`ID`), KEY `post_name` (`post_name`), KEY `type_status_date` (`post_type`,`post_status`,`post_date`,`ID`), KEY `post_parent` (`post_parent`), KEY `post_author` (`post_author`) ) ENGINE=InnoDB AUTO_INCREMENT=55004 DEFAULT CHARSET=utf8", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("CREATE TABLE `wp_term_relationships` ( `object_id` bigint(20) unsigned NOT NULL DEFAULT '0', `term_taxonomy_id` bigint(20) unsigned NOT NULL DEFAULT '0', `term_order` int(11) NOT NULL DEFAULT '0', PRIMARY KEY (`object_id`,`term_taxonomy_id`), KEY `term_taxonomy_id` (`term_taxonomy_id`) ) ENGINE=InnoDB DEFAULT CHARSET=utf8", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("CREATE TABLE `wp_term_taxonomy` ( `term_taxonomy_id` bigint(20) unsigned NOT NULL AUTO_INCREMENT, `term_id` bigint(20) unsigned NOT NULL DEFAULT '0', `taxonomy` varchar(32) NOT NULL DEFAULT '', `description` longtext NOT NULL, `parent` bigint(20) unsigned NOT NULL DEFAULT '0', `count` bigint(20) NOT NULL DEFAULT '0', PRIMARY KEY (`term_taxonomy_id`), UNIQUE KEY `term_id_taxonomy` (`term_id`,`taxonomy`), KEY `taxonomy` (`taxonomy`) ) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("CREATE TABLE `wp_terms` ( `term_id` bigint(20) unsigned NOT NULL AUTO_INCREMENT, `name` varchar(200) NOT NULL DEFAULT '', `slug` varchar(200) NOT NULL DEFAULT '', `term_group` bigint(10) NOT NULL DEFAULT '0', PRIMARY KEY (`term_id`), UNIQUE KEY `slug` (`slug`), KEY `name` (`name`) ) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("CREATE TABLE `wp_usermeta` ( `umeta_id` bigint(20) unsigned NOT NULL AUTO_INCREMENT, `user_id` bigint(20) unsigned NOT NULL DEFAULT '0', `meta_key` varchar(255) DEFAULT NULL, `meta_value` longtext, PRIMARY KEY (`umeta_id`), KEY `user_id` (`user_id`), KEY `meta_key` (`meta_key`) ) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("CREATE TABLE `wp_users` ( `ID` bigint(20) unsigned NOT NULL AUTO_INCREMENT, `user_login` varchar(60) NOT NULL DEFAULT '', `user_pass` varchar(64) NOT NULL DEFAULT '', `user_nicename` varchar(50) NOT NULL DEFAULT '', `user_email` varchar(100) NOT NULL DEFAULT '', `user_url` varchar(100) NOT NULL DEFAULT '', `user_registered` datetime NOT NULL DEFAULT '0000-00-00 00:00:00', `user_activation_key` varchar(60) NOT NULL DEFAULT '', `user_status` int(11) NOT NULL DEFAULT '0', `display_name` varchar(250) NOT NULL DEFAULT '', PRIMARY KEY (`ID`), KEY `user_login_key` (`user_login`), KEY `user_nicename` (`user_nicename`) ) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8", true);
}

public virtual void testCreateTableArrays() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("CREATE TABLE sal_emp (name text, pay_by_quarter integer[], schedule text[][])");
}

public virtual void testCreateTableArrays2() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("CREATE TABLE sal_emp (name text, pay_by_quarter integer[5], schedule text[3][2])");
}

public virtual void testCreateTableColumnValues() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("CREATE TABLE mytable1 (values INTEGER)");
}

public virtual void testCreateTableColumnValue() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("CREATE TABLE mytable1 (value INTEGER)");
}

public virtual void testCreateTableForeignKey5() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("CREATE TABLE IF NOT EXISTS table1 (id INTEGER PRIMARY KEY AUTO_INCREMENT, aid INTEGER REFERENCES accounts ON aid ON DELETE CASCADE, name STRING, lastname STRING)");
}

public virtual void testCreateTableForeignKey6() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("CREATE TABLE test (id long, fkey long references another_table (id))");
}

public virtual void testMySqlCreateTableOnUpdateCurrentTimestamp() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("CREATE TABLE test (applied timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP)");
}

public virtual void testMySqlCreateTableWithConstraintWithCascade() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("CREATE TABLE table1 (id INT (10) UNSIGNED NOT NULL AUTO_INCREMENT, t2_id INT (10) UNSIGNED DEFAULT NULL, t3_id INT (10) UNSIGNED DEFAULT NULL, t4_id INT (10) UNSIGNED NOT NULL, PRIMARY KEY (id), KEY fkc_table1_t4 (t4_id), KEY fkc_table1_t2 (t2_id), KEY fkc_table1_t3 (t3_id), CONSTRAINT fkc_table1_t2 FOREIGN KEY (t2_id) REFERENCES table_two(t2o_id) ON DELETE CASCADE ON UPDATE CASCADE, CONSTRAINT fkc_table1_t3 FOREIGN KEY (t3_id) REFERENCES table_three(t3o_id) ON UPDATE CASCADE, CONSTRAINT fkc_table1_t4 FOREIGN KEY (t4_id) REFERENCES table_four(t4o_id) ON DELETE CASCADE) ENGINE = InnoDB AUTO_INCREMENT = 8761 DEFAULT CHARSET = utf8");
}

public virtual void testMySqlCreateTableWithConstraintWithNoAction() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("CREATE TABLE table1 (id INT (10) UNSIGNED NOT NULL AUTO_INCREMENT, t2_id INT (10) UNSIGNED DEFAULT NULL, t3_id INT (10) UNSIGNED DEFAULT NULL, t4_id INT (10) UNSIGNED NOT NULL, PRIMARY KEY (id), KEY fkc_table1_t4 (t4_id), KEY fkc_table1_t2 (t2_id), KEY fkc_table1_t3 (t3_id), CONSTRAINT fkc_table1_t2 FOREIGN KEY (t2_id) REFERENCES table_two(t2o_id) ON DELETE NO ACTION ON UPDATE NO ACTION, CONSTRAINT fkc_table1_t3 FOREIGN KEY (t3_id) REFERENCES table_three(t3o_id) ON UPDATE NO ACTION, CONSTRAINT fkc_table1_t4 FOREIGN KEY (t4_id) REFERENCES table_four(t4o_id) ON DELETE NO ACTION) ENGINE = InnoDB AUTO_INCREMENT = 8761 DEFAULT CHARSET = utf8");
}

public virtual void testMySqlCreateTableWithTextIndexes() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("CREATE TABLE table2 (id INT (10) UNSIGNED NOT NULL AUTO_INCREMENT, name TEXT, url TEXT, created TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP, updated TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP, PRIMARY KEY (id), FULLTEXT KEY idx_table2_name (name)) ENGINE = InnoDB AUTO_INCREMENT = 7334 DEFAULT CHARSET = utf8");
}

public virtual void testCreateTableWithCheck() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("CREATE TABLE table2 (id INT (10) NOT NULL, name TEXT, url TEXT, CONSTRAINT name_not_empty CHECK (name <> ''))");
}

public virtual void testCreateTableWithCheckNotNull() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("CREATE TABLE table2 (id INT (10) NOT NULL, name TEXT, url TEXT, CONSTRAINT name_not_null CHECK (name IS NOT NULL))");
}

public virtual void testCreateTableIssue270() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("CREATE TABLE item (i_item_sk integer NOT NULL, i_item_id character (16) NOT NULL, i_rec_start_date date, i_rec_end_date date, i_item_desc character varying(200), i_current_price numeric(7,2), i_wholesale_cost numeric(7,2), i_brand_id integer, i_brand character(50), i_class_id integer, i_class character(50), i_category_id integer, i_category character(50), i_manufact_id integer, i_manufact character(50), i_size character(20), i_formulation character(20), i_color character(20), i_units character(10), i_container character(10), i_manager_id integer, i_product_name character(50) )", true);
}

public virtual void testCreateTableIssue270_1() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("CREATE TABLE item (i_item_sk integer NOT NULL, i_item_id character (16))");
}

public virtual void testCreateTempTableIssue293() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("CREATE GLOBAL TEMPORARY TABLE T1 (PROCESSID VARCHAR (32))");
}

public virtual void testCreateTableWithTablespaceIssue247() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("CREATE TABLE TABLE1 (COLUMN1 VARCHAR2 (15), COLUMN2 VARCHAR2 (15), CONSTRAINT P_PK PRIMARY KEY (COLUMN1) USING INDEX TABLESPACE \"T_INDEX\") TABLESPACE \"T_SPACE\"");
}

public virtual void testCreateTableWithTablespaceIssue247_1() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("CREATE TABLE TABLE1 (COLUMN1 VARCHAR2 (15), COLUMN2 VARCHAR2 (15), CONSTRAINT P_PK PRIMARY KEY (COLUMN1) USING INDEX TABLESPACE \"T_INDEX\")");
}

public virtual void testOnDeleteSetNull() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("CREATE TABLE inventory (inventory_id INT PRIMARY KEY, product_id INT, CONSTRAINT fk_inv_product_id FOREIGN KEY (product_id) REFERENCES products(product_id) ON DELETE SET NULL)");
}

public virtual void testColumnCheck() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("CREATE TABLE table1 (col1 INTEGER CHECK (col1 > 100))");
}

public virtual void testTableReferenceWithSchema() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("CREATE TABLE table1 (col1 INTEGER REFERENCES schema1.table1)");
}

public virtual void testNamedColumnConstraint() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("CREATE TABLE foo (col1 integer CONSTRAINT no_null NOT NULL)");
}

public virtual void testColumnConstraintWith() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("CREATE TABLE foo (col1 integer) WITH (fillfactor=70)");
}

public virtual void testExcludeWhereConstraint() {
string statement = "CREATE TABLE foo (col1 integer, EXCLUDE WHERE (col1 > 100))";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement);
global::DripSharp.SqlTrellis.Test.TestUtils.assertDeparse(new global::DripSharp.SqlTrellis.Statement.Create.Table.CreateTable().withTable(new global::DripSharp.SqlTrellis.Schema.Table("foo")).addIndexes(new global::DripSharp.SqlTrellis.Statement.Create.Table.ExcludeConstraint().withExpression(new global::DripSharp.SqlTrellis.Expression.Operators.Relational.GreaterThan().withLeftExpression(new global::DripSharp.SqlTrellis.Schema.Column("col1")).withRightExpression(new global::DripSharp.SqlTrellis.Expression.LongValue((long)(100))))).addColumnDefinitions(new global::DripSharp.SqlTrellis.Statement.Create.Table.ColumnDefinition("col1", new global::DripSharp.SqlTrellis.Statement.Create.Table.ColDataType("integer"))), statement);
}

public virtual void testTimestampWithoutTimezone() {
string statement = "CREATE TABLE abc.tabc (transaction_date TIMESTAMP WITHOUT TIME ZONE)";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement);
global::DripSharp.SqlTrellis.Test.TestUtils.assertDeparse(new global::DripSharp.SqlTrellis.Statement.Create.Table.CreateTable().withTable(new global::DripSharp.SqlTrellis.Schema.Table(global::DripSharp.Runtime.JavaCompat.AsList<string>("abc", "tabc"))).addColumnDefinitions(new global::DripSharp.SqlTrellis.Statement.Create.Table.ColumnDefinition("transaction_date", new global::DripSharp.SqlTrellis.Statement.Create.Table.ColDataType("TIMESTAMP WITHOUT TIME ZONE"))), statement);
}

public virtual void testCreateUnitonIssue402() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("CREATE TABLE temp.abc AS SELECT sku FROM temp.a UNION SELECT sku FROM temp.b");
}

public virtual void testCreateUnitonIssue402_2() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("CREATE TABLE temp.abc AS (SELECT sku FROM temp.a UNION SELECT sku FROM temp.b)");
}

public virtual void testCreateUnionIssue() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("CREATE TABLE temp.abc AS (SELECT c FROM t1) UNION (SELECT c FROM t2)");
}

public virtual void testTimestampWithTimezone() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("CREATE TABLE country_region (", "regionid BIGINT NOT NULL CONSTRAINT pk_auth_region PRIMARY KEY, "), "region_name VARCHAR (100) NOT NULL, "), "creation_date TIMESTAMP (0) WITH TIME ZONE DEFAULT CURRENT_TIMESTAMP (0) NOT NULL, "), "last_change_date TIMESTAMP WITH TIME ZONE DEFAULT CURRENT_TIMESTAMP (0), "), "CONSTRAINT region_name_unique UNIQUE (region_name))"));
}

public virtual void testCreateTableAsSelect3() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("CREATE TABLE public.sales1 AS (SELECT * FROM public.sales)");
}

public virtual void testQuotedPKColumnsIssue491() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("CREATE TABLE `FOO` (`ID` INT64, `NAME` STRING (100)) PRIMARY KEY (`ID`)");
}

public virtual void testQuotedPKColumnsIssue491_2() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("CREATE TABLE `FOO` (`ID` INT64, `NAME` STRING (100), PRIMARY KEY (`ID`))");
}

public virtual void testKeySyntaxWithLengthColumnParameter() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("CREATE TABLE basic (BASIC_TITLE varchar (255) NOT NULL, KEY BASIC_TITLE (BASIC_TITLE (255)))");
}

public virtual void testIssue273Varchar2Byte() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("CREATE TABLE IF NOT EXISTS \"TABLE_OK\" (\"SOME_FIELD\" VARCHAR2 (256 BYTE))");
}

public virtual void testIssue273Varchar2Char() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("CREATE TABLE IF NOT EXISTS \"TABLE_OK\" (\"SOME_FIELD\" VARCHAR2 (256 CHAR))");
}

public virtual void testIssue661Partition() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("CREATE TABLE T_TEST_PARTITION (PART_COLUMN VARCHAR2 (32) NOT NULL, OTHER_COLS VARCHAR2 (10) NOT NULL) TABLESPACE TBS_DATA_01 PARTITION BY HASH (PART_COLUMN) PARTITIONS 4 STORE IN (TBS_DATA_01) COMPRESS");
}

public virtual void testIssue770Using() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("CREATE TABLE `department_region` (`ID` int(11) unsigned NOT NULL AUTO_INCREMENT COMMENT '\u81EA\u589E\u4E3B\u952E', `DEPARTMENT_ID` int(10) unsigned NOT NULL COMMENT '\u90E8\u95E8ID', PRIMARY KEY (`ID`) KEY `DISTRICT_CODE` (`DISTRICT_CODE`)  USING BTREE) ENGINE=InnoDB AUTO_INCREMENT=420 DEFAULT CHARSET=utf8", true);
}

public virtual void testRUBiSCreateList() {
global::System.IO.TextReader @in = global::DripSharp.Runtime.JavaCompat.NewInputStreamReader(global::DripSharp.SqlTrellis.Tests.Support.ResourceStream(typeof(global::DripSharp.SqlTrellis.Statement.Create.CreateTableTest), "/RUBiS-create-requests.txt"));
try {
int numSt = 1;
while (true) {
string line = this.getLine(@in);
if ((line == default!)) {
break;
}
if (!(global::DripSharp.Runtime.JavaCompat.Equals("#begin", line))) {
break;
}
line = this.getLine(@in);
global::System.Text.StringBuilder buf = new global::System.Text.StringBuilder(line);
while (true) {
line = this.getLine(@in);
if (global::DripSharp.Runtime.JavaCompat.Equals("#end", line)) {
break;
}
buf.Append("\n");
buf.Append(line);
}
string query = buf.ToString();
if (!(global::DripSharp.Runtime.JavaCompat.Equals(this.getLine(@in), "true"))) {
continue;
}
string tableName = this.getLine(@in);
string cols = this.getLine(@in);
try {
global::DripSharp.SqlTrellis.Statement.Create.Table.CreateTable createTable = (global::DripSharp.SqlTrellis.Statement.Create.Table.CreateTable)(this.parserManager.parse(new global::System.IO.StringReader(query))!);
string[] colsList = default!;
if (global::DripSharp.Runtime.JavaCompat.Equals("null", cols)) {
colsList = new string[0];
} else {
global::DripSharp.Runtime.JavaStringTokenizer tokenizer = new global::DripSharp.Runtime.JavaStringTokenizer(cols, " ");
global::System.Collections.Generic.IList<string> colsListList = new global::System.Collections.Generic.List<string>();
while (tokenizer.hasMoreTokens()) {
global::DripSharp.Runtime.JavaCompat.Add(colsListList, tokenizer.nextToken());
}
colsList = global::DripSharp.Runtime.JavaCompat.CollectionToArray(colsListList, new string[global::DripSharp.Runtime.JavaCompat.CollectionCount(colsListList)]);
}
global::System.Collections.Generic.IList<string> colsFound = new global::System.Collections.Generic.List<string>();
if ((createTable.getColumnDefinitions() != default!)) {
foreach (global::DripSharp.SqlTrellis.Statement.Create.Table.ColumnDefinition columnDefinition in createTable.getColumnDefinitions()) {
string colName = columnDefinition.getColumnName();
bool unique = false;
if ((createTable.getIndexes() != default!)) {
foreach (global::DripSharp.SqlTrellis.Statement.Create.Table.Index index in createTable.getIndexes()) {
if (((global::DripSharp.Runtime.JavaCompat.Equals(index.getType(), "PRIMARY KEY") && (global::DripSharp.Runtime.JavaCompat.CollectionCount(index.getColumnsNames()) == 1)) && global::DripSharp.Runtime.JavaCompat.Equals(global::DripSharp.Runtime.JavaCompat.ListGet(index.getColumnsNames(), 0), colName))) {
unique = true;
}
}
}
if (!unique) {
if ((columnDefinition.getColumnSpecs() != default!)) {
for (global::DripSharp.Runtime.JavaIterator<string> iterator = global::DripSharp.Runtime.JavaCompat.Iterator(columnDefinition.getColumnSpecs()); iterator.HasNext(); ) {
string par = iterator.Next()!;
if (global::DripSharp.Runtime.JavaCompat.Equals(par, "UNIQUE")) {
unique = true;
} else {
if (((global::DripSharp.Runtime.JavaCompat.Equals(par, "PRIMARY") && iterator.HasNext()) && global::DripSharp.Runtime.JavaCompat.Equals(iterator.Next()!, "KEY"))) {
unique = true;
}
}
}
}
}
if (unique) {
colName += ".unique";
}
global::DripSharp.Runtime.JavaCompat.Add(colsFound, colName.ToLowerInvariant());
}
}
global::DripSharp.Testing.JavaAssertions.Equal(colsList!.Length, global::DripSharp.Runtime.JavaCompat.CollectionCount(colsFound), global::DripSharp.Runtime.JavaCompat.Concat("stm:", query));
for (int i = 0; (i < colsList!.Length); i++) {
global::DripSharp.Testing.JavaAssertions.Equal(colsList![i], global::DripSharp.Runtime.JavaCompat.ListGet(colsFound, i), global::DripSharp.Runtime.JavaCompat.Concat("stm:", query));
}
} catch (global::System.Exception e) when (e is not global::System.TypeInitializationException) {
throw new global::DripSharp.SqlTrellis.Test.TestException(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("error at stm num: ", numSt), "  "), query), e);
}
numSt++;
}
} finally {
if ((@in != default!)) {
@in.Dispose();
}
}
}

private string getLine(global::System.IO.TextReader @in) {
string line = default!;
while (true) {
line = @in.ReadLine();
if ((line! != default!)) {
if (((line!.Length != 0) && ((line!.Length < 2) || ((line!.Length >= 2) && !((((int)(line![0]) == (int)('/')) && ((int)(line![1]) == (int)('/')))))))) {
break;
}
} else {
break;
}
}
return line!;
}

public virtual void testCollateUtf8Issue785() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("CREATE TABLE DEMO_SQL (SHARE_PWD varchar (128) COLLATE utf8_bin NOT NULL DEFAULT '' COMMENT 'COMMENT') ENGINE = InnoDB AUTO_INCREMENT = 34 DEFAULT CHARSET = utf8 COLLATE = utf8_bin COMMENT = 'COMMENT'");
}

public virtual void testCreateTableWithSetTypeIssue796() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("CREATE TABLE `tables_priv` (`Host` char (60) COLLATE utf8_bin NOT NULL DEFAULT '', `Table_priv` set ('Select', 'Insert', 'Update', 'Delete', 'Create', 'Drop', 'Grant', 'References', 'Index', 'Alter', 'Create View', 'Show view', 'Trigger') CHARACTER SET utf8 NOT NULL DEFAULT '') ENGINE = MyISAM DEFAULT CHARSET = utf8 COLLATE = utf8_bin COMMENT = 'Table privileges'");
}

public virtual void testCreateTableIssue798() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("CREATE TABLE `comment` (`text_hash` varchar (32) COLLATE utf8_bin)");
}

public virtual void testCreateTableIssue798_2() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("CREATE TABLE parent (\n", "PARENT_ID int(11) NOT NULL AUTO_INCREMENT,\n"), "PCN varchar(100) NOT NULL,\n"), "IS_DELETED char(1) NOT NULL,\n"), "STRUCTURE_ID int(11) NOT NULL,\n"), "DIRTY_STATUS char(1) NOT NULL,\n"), "BIOLOGICAL char(1) NOT NULL,\n"), "STRUCTURE_TYPE int(11) NOT NULL,\n"), "CST_ORIGINAL varchar(1000) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,\n"), "MWT decimal(14,6) DEFAULT NULL,\n"), "RESTRICTED int(11) NOT NULL,\n"), "INIT_DATE datetime DEFAULT NULL,\n"), "MOD_DATE datetime DEFAULT NULL,\n"), "CREATED_BY varchar(255) NOT NULL,\n"), "MODIFIED_BY varchar(255) NOT NULL,\n"), "CHEMIST_ID varchar(255) NOT NULL,\n"), "UNKNOWN_ID int(11) DEFAULT NULL,\n"), "STEREOCHEMISTRY varchar(256) DEFAULT NULL,\n"), "GEOMETRIC_ISOMERISM varchar(256) DEFAULT NULL,\n"), "PRIMARY KEY (PARENT_ID),\n"), "UNIQUE KEY PARENT_PCN_IDX (PCN),\n"), "KEY PARENT_SID_IDX (STRUCTURE_ID),\n"), "KEY PARENT_DIRTY_IDX (DIRTY_STATUS)\n"), ") ENGINE=InnoDB AUTO_INCREMENT=2663 DEFAULT CHARSET=utf8"), true);
}

public virtual void testCreateTableIssue113() {
string statement = "CREATE TABLE foo (reason character varying (255) DEFAULT 'Test' :: character varying NOT NULL)";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement);
global::DripSharp.SqlTrellis.Test.TestUtils.assertDeparse(new global::DripSharp.SqlTrellis.Statement.Create.Table.CreateTable().withTable(new global::DripSharp.SqlTrellis.Schema.Table().withName("foo")).withColumnDefinitions(global::DripSharp.Runtime.JavaCompat.AsList<global::DripSharp.SqlTrellis.Statement.Create.Table.ColumnDefinition>(new global::DripSharp.SqlTrellis.Statement.Create.Table.ColumnDefinition().withColumnName("reason").withColDataType(new global::DripSharp.SqlTrellis.Statement.Create.Table.ColDataType().withDataType("character varying").addArgumentsStringList(global::DripSharp.Runtime.JavaCompat.AsList<string>("255"))).addColumnSpecs("DEFAULT 'Test' :: character varying", "NOT NULL"))), statement);
}

public virtual void testCreateTableIssue830() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("CREATE TABLE testyesr (id int, yy year)");
}

public virtual void testCreateTableIssue830_2() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("CREATE TABLE testyesr (id int, yy year, mm month, dd day)");
}

public virtual void testSettingCharacterSetIssue829() {
string sql = "CREATE TABLE test (id int (11) NOT NULL, name varchar (64) CHARACTER SET GBK NOT NULL, age int (11) NOT NULL, score decimal (8, 2) DEFAULT NULL, description varchar (64) DEFAULT NULL, creationDate datetime DEFAULT CURRENT_TIMESTAMP, PRIMARY KEY (id)) ENGINE = InnoDB DEFAULT CHARSET = utf8mb4";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sql);
global::DripSharp.SqlTrellis.Statement.Create.Table.CreateTable stmt = (global::DripSharp.SqlTrellis.Statement.Create.Table.CreateTable)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sql)!);
global::DripSharp.SqlTrellis.Statement.Create.Table.ColumnDefinition colName = global::DripSharp.Runtime.JavaCompat.FindFirstOptional(global::DripSharp.Runtime.JavaCompat.StreamFilter(global::DripSharp.Runtime.JavaCompat.Stream(stmt.getColumnDefinitions()), (col) => global::DripSharp.Runtime.JavaCompat.Equals(col.getColumnName(), "name"))).OrElse(default!);
global::DripSharp.Testing.JavaAssertions.NotNull(colName, null);
global::DripSharp.Testing.JavaAssertions.Equal("GBK", colName.getColDataType().getCharacterSet(), null);
}

public virtual void testCreateTableIssue924() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("CREATE TABLE test_descending_indexes (c1 INT, c2 INT, INDEX idx1 (c1 ASC, c2 DESC))");
}

public virtual void testCreateTableIssue924_2() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("CREATE TABLE test_descending_indexes (c1 INT, c2 INT, INDEX idx1 (c1 ASC, c2 ASC), INDEX idx2 (c1 ASC, c2 DESC), INDEX idx3 (c1 DESC, c2 ASC), INDEX idx4 (c1 DESC, c2 DESC))");
}

public virtual void testCreateTableIssue921() {
string statement = "CREATE TABLE binary_test (c1 binary (10))";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement);
global::DripSharp.SqlTrellis.Test.TestUtils.assertDeparse(new global::DripSharp.SqlTrellis.Statement.Create.Table.CreateTable().withTable(new global::DripSharp.SqlTrellis.Schema.Table().withName("binary_test")).addColumnDefinitions(new global::DripSharp.SqlTrellis.Statement.Create.Table.ColumnDefinition("c1", new global::DripSharp.SqlTrellis.Statement.Create.Table.ColDataType().withDataType("binary").addArgumentsStringList("10"), (global::System.Collections.Generic.IList<string>)default!)), statement);
}

public virtual void testCreateTableWithComments() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("CREATE TABLE IF NOT EXISTS `eai_applications`(\n", "  `id` bigint(20) unsigned NOT NULL AUTO_INCREMENT COMMENT 'comment',\n"), "  `name` varchar(64) NOT NULL COMMENT 'comment',\n"), "  `logo` varchar(128) DEFAULT NULL COMMENT 'comment',\n"), "  `description` varchar(128) DEFAULT NULL COMMENT 'comment',\n"), "  `type` int(11) NOT NULL COMMENT 'comment',\n"), "  `status` tinyint(2) NOT NULL COMMENT 'comment',\n"), "  `creator_id` bigint(20) NOT NULL COMMENT 'comment',\n"), "  `created_at` datetime NOT NULL COMMENT 'comment',\n"), "  `updated_at` datetime NOT NULL COMMENT 'comment',\n"), "  PRIMARY KEY (`id`)\n"), ") COMMENT='comment'"), true);
}

public virtual void testCreateTableWithCommentIssue922() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("CREATE TABLE index_with_comment_test (\n", "id int(11) NOT NULL,\n"), "name varchar(60) DEFAULT NULL,\n"), "KEY name_ind (name) COMMENT 'comment for the name index'\n"), ") ENGINE=InnoDB DEFAULT CHARSET=utf8"), true);
}

public virtual void testEnableRowMovementOption() {
string sql = "CREATE TABLE test (startdate DATE) ENABLE ROW MOVEMENT";
global::DripSharp.SqlTrellis.Statement.Create.Table.CreateTable createTable = (global::DripSharp.SqlTrellis.Statement.Create.Table.CreateTable)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sql)!);
global::DripSharp.Testing.JavaAssertJ.That(createTable.getRowMovement()).IsNotNull();
global::DripSharp.Testing.JavaAssertJ.That(createTable.getRowMovement().getMode()).IsEqualTo(global::DripSharp.SqlTrellis.Statement.Create.Table.RowMovementMode.ENABLE);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sql);
}

public virtual void testDisableRowMovementOption() {
string sql = "CREATE TABLE test (startdate DATE) DISABLE ROW MOVEMENT";
global::DripSharp.SqlTrellis.Statement.Create.Table.CreateTable createTable = (global::DripSharp.SqlTrellis.Statement.Create.Table.CreateTable)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sql)!);
global::DripSharp.Testing.JavaAssertJ.That(createTable.getRowMovement()).IsNotNull();
global::DripSharp.Testing.JavaAssertJ.That(createTable.getRowMovement().getMode()).IsEqualTo(global::DripSharp.SqlTrellis.Statement.Create.Table.RowMovementMode.DISABLE);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sql);
}

public virtual void tableMovementWithAS() {
string sql = "CREATE TABLE test (startdate DATE) DISABLE ROW MOVEMENT AS SELECT 1 FROM dual";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sql);
}

public virtual void testCreateTableWithCommentIssue413() {
string statement = "CREATE TABLE a LIKE b";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement);
}

public virtual void testCreateTableWithCommentIssue413_2() {
string statement = "CREATE TABLE a LIKE (b)";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement);
}

public virtual void testCreateTableWithParameterDefaultFalseIssue1089() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("create table ADDRESS_TYPE ( address_type CHAR(1) not null, at_name VARCHAR(250) not null, is_disabled BOOL not null default FALSE, constraint PK_ADDRESS_TYPE primary key (address_type) )", true);
}

public virtual void testDefaultArray() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("CREATE TABLE t (f1 text[] DEFAULT ARRAY[] :: text[] NOT NULL, f2 int[] DEFAULT ARRAY[1, 2])");
}

public virtual void testCreateTemporaryTableAsSelect() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("CREATE TEMPORARY TABLE T1 (C1, C2) AS SELECT C3, C4 FROM T2");
}

public virtual void testCreateTempTableAsSelect() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("CREATE TEMP TABLE T1 (C1, C2) AS SELECT C3, C4 FROM T2");
}

public virtual void testCreateTableIssue1230() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("CREATE TABLE TABLE_HISTORY (ID bigint generated by default as identity, CREATED_AT timestamp not null, TEXT varchar (255), primary key (ID))");
}

public virtual void testCreateUnionIssue1309() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("CREATE TABLE temp.abc AS (SELECT c FROM t1) UNION (SELECT c FROM t2)");
}

public virtual void testCreateTableBinaryIssue1518() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("CREATE TABLE `s` (`a` enum ('a', 'b', 'c') CHARACTER SET binary COLLATE binary)");
}

public virtual void testCreateTableIssue1488() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("CREATE TABLE u_call_record (\n", "card_user_id int(11) NOT NULL,\n"), "device_id int(11) NOT NULL,\n"), "call_start_at int(11) NOT NULL DEFAULT CURRENT_TIMESTAMP(11),\n"), "card_user_name varchar(32) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,\n"), "sim_id varchar(32) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,\n"), "called_number varchar(12) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,\n"), "called_nickname varchar(32) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,\n"), "talk_time smallint(8) NULL DEFAULT NULL,\n"), "area_name varchar(32) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,\n"), "area_service_id int(11) NULL DEFAULT NULL,\n"), "operator_id int(4) NULL DEFAULT NULL,\n"), "status tinyint(4) NULL DEFAULT NULL,\n"), "create_at timestamp NULL DEFAULT NULL,\n"), "place_user varchar(16) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,\n"), "PRIMARY KEY (card_user_id, device_id, call_start_at) USING BTREE,\n"), "INDEX ucr_index_area_name(area_name) USING BTREE,\n"), "INDEX ucr_index_area_service_id(area_service_id) USING BTREE,\n"), "INDEX ucr_index_called_number(called_number) USING BTREE,\n"), "INDEX ucr_index_create_at(create_at) USING BTREE,\n"), "INDEX ucr_index_operator_id(operator_id) USING BTREE,\n"), "INDEX ucr_index_place_user(place_user) USING BTREE,\n"), "INDEX ucr_index_sim_id(sim_id) USING BTREE,\n"), "INDEX ucr_index_status(status) USING BTREE,\n"), "INDEX ucr_index_talk_time(talk_time) USING BTREE\n"), ") ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = Dynamic"), true);
}

public virtual void testCreateTableBinaryIssue1596() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("CREATE TABLE student2 (", "id int (10) NOT NULL COMMENT 'ID', "), "name varchar (20) COLLATE utf8mb4_bin DEFAULT NULL, "), "birth year (4) DEFAULT NULL, "), "department varchar (20) COLLATE utf8mb4_bin DEFAULT NULL, "), "address varchar (50) COLLATE utf8mb4_bin DEFAULT NULL, "), "PRIMARY KEY (id), "), "UNIQUE KEY id (id), "), "INDEX name (name) USING BTREE"), ") ENGINE = InnoDB DEFAULT CHARSET = utf8mb4 COLLATE = utf8mb4_bin"));
}

public virtual void testCreateTableSpanner() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("CREATE TABLE COMMAND (\n", "   DATASET_ID      INT64       NOT NULL,\n"), "   COMMAND_ID      STRING(MAX) NOT NULL,\n"), "   VAL_BOOL        BOOL,\n"), "   VAL_BYTES       BYTES(1024),\n"), "   VAL_DATE        DATE,\n"), "   VAL_TIMESTAMP   TIMESTAMP,\n"), "   VAL_COMMIT_TIMESTAMP   TIMESTAMP NOT NULL OPTIONS (allow_commit_timestamp = true),\n"), "   VAL_FLOAT64     FLOAT64,\n"), "   VAL_JSON        JSON(2048),\n"), "   VAL_NUMERIC     NUMERIC,\n"), "   VAL_STRING      STRING(MAX),\n"), "   VAL_TIMESTAMP   TIMESTAMP,\n"), "   ARR_BOOL        ARRAY<BOOL>,\n"), "   ARR_BYTES       ARRAY<BYTES(1024)>,\n"), "   ARR_DATE        ARRAY<DATE>,\n"), "   ARR_TIMESTAMP   ARRAY<TIMESTAMP>,\n"), "   ARR_FLOAT64     ARRAY<FLOAT64>,\n"), "   ARR_JSON        ARRAY<JSON(2048)>,\n"), "   ARR_NUMERIC     ARRAY<NUMERIC>,\n"), "   ARR_STRING      ARRAY<STRING(MAX)>,\n"), "   ARR_TIMESTAMP   ARRAY<TIMESTAMP>,\n"), "   PAYLOAD         STRING(MAX),\n"), "   AUTHOR          STRING(MAX) NOT NULL,\n"), "   SEARCH          STRING(MAX) AS (UPPER(AUTHOR)) STORED\n"), " ) PRIMARY KEY ( DATASET_ID, COMMAND_ID )\n"), ",   INTERLEAVE IN PARENT DATASET ON DELETE CASCADE"), true);
}

internal virtual void testCreateTableWithStartWithNumber() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("CREATE TABLE locations\n", "  (\n"), "    location_id NUMBER GENERATED BY DEFAULT AS IDENTITY START WITH 24 \n"), "                PRIMARY KEY       ,\n"), "    address     VARCHAR2( 255 ) NOT NULL,\n"), "    postal_code VARCHAR2( 20 )          ,\n"), "    city        VARCHAR2( 50 )          ,\n"), "    state       VARCHAR2( 50 )          ,\n"), "    country_id  CHAR( 2 )               , -- fk\n"), "    CONSTRAINT fk_locations_countries \n"), "      FOREIGN KEY( country_id )\n"), "      REFERENCES countries( country_id ) \n"), "      ON DELETE CASCADE\n"), "  )");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

internal virtual void testCreateTableWithNextValueFor() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("CREATE TABLE public.actor (\n", "    actor_id integer DEFAULT nextval('public.actor_actor_id_seq'::regclass) NOT NULL\n"), ")");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(" CREATE TABLE myschema.tableName (\n", "                id bigint NOT NULL DEFAULT nextval('myschema.mysequence'::regclass), \n"), "                bool_col boolean NOT NULL DEFAULT false, \n"), "                int_col integer NOT NULL DEFAULT 0)");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(" CREATE TABLE t1 (\n", "  -- literal defaults\n"), "  i INT         DEFAULT 0,\n"), "  c VARCHAR(10) DEFAULT '',\n"), "  -- expression defaults\n"), "  f FLOAT       DEFAULT (RAND() * RAND()),\n"), "  b BINARY(16)  DEFAULT (UUID_TO_BIN(UUID())),\n"), "  d DATE        DEFAULT (CURRENT_DATE + INTERVAL 1 YEAR),\n"), "  p POINT       DEFAULT (Point(0,0)),\n"), "  j JSON        DEFAULT (JSON_ARRAY())\n"), ")");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(" CREATE TABLE pagila_dev.actor (\n", "actor_id integer DEFAULT nextval('pagila_dev.actor_actor_id_seq'::regclass) NOT NULL,\n"), "first_name text NOT NULL,\n"), "last_name text NOT NULL,\n"), "last_update timestamp with time zone DEFAULT now() NOT NULL\n"), ")");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("CREATE TABLE \"public\".\"device_bayonet_copy1\" ( ", "\"id\" int8 NOT NULL"), ", \"device_code\" varchar(128) COLLATE \"pg_catalog\".\"default\""), ", \"longitude_latitude\" varchar(128) COLLATE \"pg_catalog\".\"default\""), ", \"longitude_latitude_gis\" \"public\".\"geometry\""), ", \"direction\" varchar(128) COLLATE \"pg_catalog\".\"default\""), ", \"brand\" varchar(128) COLLATE \"pg_catalog\".\"default\""), ", \"test\" \"information_schema\".\"time_stamp\""), ", CONSTRAINT \"device_bayonet_copy1_pkey\" PRIMARY KEY (\"id\") "), ")");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

internal virtual void testIssue1858() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("CREATE TABLE \"foo\"\n", "(\n"), "    event_sk               bigint identity             NOT NULL encode RAW\n"), ") compound sortkey (      date_key      )");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

internal virtual void testIssue1864() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("ALTER TABLE `test`.`test_table` ", "MODIFY COLUMN `test` varchar(251) "), " CHARACTER SET armscii8 COLLATE armscii8_bin NULL DEFAULT NULL FIRST");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

internal virtual void testUniqueAfterForeignKeyIssue2082() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("CREATE TABLE employees (\n", "employee_number    int         NOT NULL\n"), ", employee_name    char (50)   NOT NULL\n"), ", department_id    int\n"), ", salary           int\n"), ", PRIMARY KEY (employee_number)\n"), ", FOREIGN KEY (department_id) REFERENCES departments(id)\n"), ", UNIQUE (employee_name));");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

[Xunit.Fact]
public void __Upstream_7148c3ad20974198()
{
        try
        {
            this.tableMovementWithAS();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_b802d373da5c93ce()
{
        try
        {
            this.testCollateUtf8Issue785();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_a0a374c0486a998e()
{
        try
        {
            this.testColumnCheck();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_c88ff269ed835dd3()
{
        try
        {
            this.testColumnConstraintWith();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_6c1afc0b50009abc()
{
        try
        {
            this.testCreateTable();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_623ab5a8d88d592e()
{
        try
        {
            this.testCreateTable2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_6506f5afb334cbed()
{
        try
        {
            this.testCreateTable3();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_c1f6545fea60a50d()
{
        try
        {
            this.testCreateTableArrays();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_be522ed0f748e358()
{
        try
        {
            this.testCreateTableArrays2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_1b98abac0d5e32aa()
{
        try
        {
            this.testCreateTableAsSelect();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_8cfa3fad7ed17127()
{
        try
        {
            this.testCreateTableAsSelect2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_50b8bc82eda45363()
{
        try
        {
            this.testCreateTableAsSelect3();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_b15d4e1fa79abaa1()
{
        try
        {
            this.testCreateTableBinaryIssue1518();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_1cc82e3bc3ce15a9()
{
        try
        {
            this.testCreateTableBinaryIssue1596();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_f8d829665038d8e2()
{
        try
        {
            this.testCreateTableColumnValue();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_9b0d11661185e0d5()
{
        try
        {
            this.testCreateTableColumnValues();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_76f9e0f8013329c2()
{
        try
        {
            this.testCreateTableDefault();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_67d8607d39c12a5d()
{
        try
        {
            this.testCreateTableDefault2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_3b608f3cc83f3d23()
{
        try
        {
            this.testCreateTableForeignKey();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_1842e6674f189e6c()
{
        try
        {
            this.testCreateTableForeignKey2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_ec32f5e6857c8def()
{
        try
        {
            this.testCreateTableForeignKey3();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_81c02ab9f91afe65()
{
        try
        {
            this.testCreateTableForeignKey4();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_46bd83b274bd3fa5()
{
        try
        {
            this.testCreateTableForeignKey5();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_655f54c2bf93da15()
{
        try
        {
            this.testCreateTableForeignKey6();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_58ef152e65749f84()
{
        try
        {
            this.testCreateTableIfNotExists();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_8b637b3b59e68623()
{
        try
        {
            this.testCreateTableInlinePrimaryKey();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_ba80c608e1af30a7()
{
        try
        {
            this.testCreateTableIssue113();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_12867d579a751536()
{
        try
        {
            this.testCreateTableIssue1230();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_98bda0f5995f6806()
{
        try
        {
            this.testCreateTableIssue1488();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_7cf2bd323c46256f()
{
        try
        {
            this.testCreateTableIssue270();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_bcaa0a2645026139()
{
        try
        {
            this.testCreateTableIssue270_1();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_5dbe55a7c72e4ce0()
{
        try
        {
            this.testCreateTableIssue798();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_5a0fd0c4ccaba277()
{
        try
        {
            this.testCreateTableIssue798_2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_f9e0e800e5cf1334()
{
        try
        {
            this.testCreateTableIssue830();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_7032e9aed3e8656d()
{
        try
        {
            this.testCreateTableIssue830_2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_8be698ed4926e929()
{
        try
        {
            this.testCreateTableIssue921();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_d3c10aa350185f72()
{
        try
        {
            this.testCreateTableIssue924();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_56c524e80b594a84()
{
        try
        {
            this.testCreateTableIssue924_2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_e1bfdf1c00ffde30()
{
        try
        {
            this.testCreateTableOrReplace();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_3dcba3a739285a27()
{
        try
        {
            this.testCreateTableParams();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_a1b9c99954772ca4()
{
        try
        {
            this.testCreateTableParams2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_0af510ea6fbc39a5()
{
        try
        {
            this.testCreateTablePrimaryKey();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_25246bf8ccdf71bd()
{
        try
        {
            this.testCreateTableSpanner();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_b740743ba8142d36()
{
        try
        {
            this.testCreateTableUniqueConstraint();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_5420c641af36beb4()
{
        try
        {
            this.testCreateTableUniqueConstraintAfterPrimaryKey();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_081bc999fe028e73()
{
        try
        {
            this.testCreateTableUnlogged();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_c86b380e278d32db()
{
        try
        {
            this.testCreateTableUnlogged2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_fd94ffb37d13bd2e()
{
        try
        {
            this.testCreateTableVeryComplex();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_0e941fa982d59e52()
{
        try
        {
            this.testCreateTableWithCheck();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_e6323cf3750eb800()
{
        try
        {
            this.testCreateTableWithCheckNotNull();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_0683d7aef0217149()
{
        try
        {
            this.testCreateTableWithCommentIssue413();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_911b3a52eacd1a99()
{
        try
        {
            this.testCreateTableWithCommentIssue413_2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_a92b71417ff17a10()
{
        try
        {
            this.testCreateTableWithCommentIssue922();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_a4f764bb44a230cd()
{
        try
        {
            this.testCreateTableWithComments();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_4875c0b21ff1f5af()
{
        try
        {
            this.testCreateTableWithKey();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_9197149104f65124()
{
        try
        {
            this.testCreateTableWithNextValueFor();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_e09391b6e217b994()
{
        try
        {
            this.testCreateTableWithParameterDefaultFalseIssue1089();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_c6e87436a6fbe623()
{
        try
        {
            this.testCreateTableWithRange();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_ea5217be6fe11b00()
{
        try
        {
            this.testCreateTableWithSetTypeIssue796();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_0d439cbe36eb240b()
{
        try
        {
            this.testCreateTableWithStartWithNumber();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_5d68e5319addc2e0()
{
        try
        {
            this.testCreateTableWithTablespaceIssue247();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_0941ee5d724f4bcb()
{
        try
        {
            this.testCreateTableWithTablespaceIssue247_1();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_74d46c4aa3a629df()
{
        try
        {
            this.testCreateTableWithUniqueKey();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_190d5db70f4ff36c()
{
        try
        {
            this.testCreateTempTableAsSelect();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_2ccc30add969fdb9()
{
        try
        {
            this.testCreateTempTableIssue293();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_3f568ed5ef0e10c6()
{
        try
        {
            this.testCreateTemporaryTableAsSelect();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_849e82eb755f6377()
{
        try
        {
            this.testCreateUnionIssue();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_08a59ce46b32c5be()
{
        try
        {
            this.testCreateUnionIssue1309();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_34465b3e9a0bc6f4()
{
        try
        {
            this.testCreateUnitonIssue402();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_cd8319eb67488f56()
{
        try
        {
            this.testCreateUnitonIssue402_2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_58d66a864e990101()
{
        try
        {
            this.testDefaultArray();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_8f45229e0f389dc7()
{
        try
        {
            this.testDisableRowMovementOption();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_5c687d2c6a18c5dd()
{
        try
        {
            this.testEnableRowMovementOption();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_2b48a22c28d606d3()
{
        try
        {
            this.testExcludeWhereConstraint();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_e4f2ed51e0562d4c()
{
        try
        {
            this.testIssue1858();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_81312238a27be4d8()
{
        try
        {
            this.testIssue1864();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_48cacf71a7ed5f71()
{
        try
        {
            this.testIssue273Varchar2Byte();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_98f7472a4137bd87()
{
        try
        {
            this.testIssue273Varchar2Char();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_0795efd8317e3b1b()
{
        try
        {
            this.testIssue661Partition();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_7b3fc5220919cf53()
{
        try
        {
            this.testIssue770Using();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_d4c4068ae67af58a()
{
        try
        {
            this.testKeySyntaxWithLengthColumnParameter();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_aa0dd37d13934815()
{
        try
        {
            this.testMySqlCreateTableOnUpdateCurrentTimestamp();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_e4ff9b0c08082b24()
{
        try
        {
            this.testMySqlCreateTableWithConstraintWithCascade();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_f7e975062bb1e4c0()
{
        try
        {
            this.testMySqlCreateTableWithConstraintWithNoAction();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_bf192b1b780a10ad()
{
        try
        {
            this.testMySqlCreateTableWithTextIndexes();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_d87291ae75650689()
{
        try
        {
            this.testNamedColumnConstraint();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_9efde2240a23456a()
{
        try
        {
            this.testOnDeleteSetNull();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_af9a5c4ce8d81e12()
{
        try
        {
            this.testQuotedPKColumnsIssue491();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_80d46fb118719b40()
{
        try
        {
            this.testQuotedPKColumnsIssue491_2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_3136ee3ce7d5ed71()
{
        try
        {
            this.testRUBiSCreateList();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_b2604353e0e69e11()
{
        try
        {
            this.testSettingCharacterSetIssue829();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_ac91c53c5f6f6edc()
{
        try
        {
            this.testTableReferenceWithSchema();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_17e8c049782bc734()
{
        try
        {
            this.testTimestampWithTimezone();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_1f733965596f2721()
{
        try
        {
            this.testTimestampWithoutTimezone();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_4a400ac09f37207a()
{
        try
        {
            this.testUniqueAfterForeignKeyIssue2082();
        }
        finally
        {
        }
}
}
