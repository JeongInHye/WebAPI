using System;
using System.Collections;
using MySql.Data.MySqlClient;

namespace WebAPI.Modules
{
    public class Test
    {
        public string id
        {
            set;
            get;
        }

        public string name
        {
            set;
            get;
        }

        public string passwd
        {
            set;
            get;
        }
    }

    public static class Query
    {
        public static ArrayList GetInsert(Test test)
        {
            MYsql my = new MYsql();
            string sql = string.Format("insert into test values ('{0}','{1}','{2}');",test.id,test.name,test.passwd);
            if (my.NonQuery(sql))
            {
                return GetSelect();
            }
            else
            {
                return new ArrayList();
            }
        }

        public static ArrayList GetUpdate(Test test)
        {
            MYsql my = new MYsql();
            string sql = string.Format("update test SET NAME = '{0}',passwd='{1}' WHERE id = '{2}';",test.name,test.passwd,test.id);
            if(my.NonQuery(sql))
            {
                return GetSelect();
            }
            else
            {
                return new ArrayList();
            }
        }

        public static ArrayList GetDelete(Test test)
        {
            MYsql my = new MYsql();
            string sql = string.Format("DELETE FROM test WHERE id = '{0}';",test.id);
            if(my.NonQuery(sql))
            {
                return GetSelect();
            }
            else
            {
                return new ArrayList();
            }
        }

        public static ArrayList GetSelect()
        {
            MYsql my = new MYsql();
            string sql = string.Format("select * from test;");
            MySqlDataReader sdr = my.Reader(sql);
            ArrayList list = new ArrayList();
            while (sdr.Read())
            {
                Hashtable ht = new Hashtable();
                for (int i = 0; i < sdr.FieldCount; i++)
                {
                    ht.Add(sdr.GetName(i),sdr.GetValue(i));
                }
                list.Add(ht);
            }
            return list;
        }
    }
}