using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C971_MobileApp.Models;
using SQLite;

namespace C971_MobileApp.Data
{
    public class TermData
    {
        string dbPath;
        private SQLiteConnection conn;
        public List<Term> termList = new List<Term>();

        public TermData(string dbPath)
        {
            this.dbPath = dbPath;
        }

        public TermData()
        {
        }

        public void Init()
        {
            conn = new SQLiteConnection(this.dbPath);
            conn.CreateTable<Term>();
        }
        public List<Term> GetAllTerms()
        {
            Init();
            return conn.Table<Term>().ToList();
        }
        public Term GetTermById(int id)
        {
            Init();
            return conn.FindWithQuery<Term>("SELECT * FROM term WHERE Id = ?", id);
        }
        public Term AddTerm(Term term)
        {
            if (term.Active)
            {
                DeactivateAllTerms();
            }
            conn = new SQLiteConnection(this.dbPath);
            conn.Insert(term);
            return term;
        }
        public void DeleteTerm(int id)
        {
            conn = new SQLiteConnection(this.dbPath);
            conn.Delete(new Term { Id = id });
        }
        public void EditTerm(Term term)
        {
            if(term.Active)
            {
                DeactivateAllTerms();
            }
            conn = new SQLiteConnection(this.dbPath);
            conn.Update(term);
        }
        private void DeactivateAllTerms()
        {
            Init();
            Term activeTerm = conn.FindWithQuery<Term>("SELECT * FROM term WHERE active = 1");
            if (activeTerm != null)
            {
                activeTerm.Active = false;
                conn.Update(activeTerm);
            }
        }
        public void ActivateTerm(Term term)
        {
            Init();
            DeactivateAllTerms();
            term.Active = true;
            conn.Update(term);
        }
    }
}
