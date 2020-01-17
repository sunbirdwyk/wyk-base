using System.Collections.Generic;
using wyk.basic;

namespace wyk.db.tool.Model
{
    public class MaintainGroup
    {
        public List<MaintainProject> projects = new List<MaintainProject>();

        public MaintainProject get(string name)
        {
            foreach (var proj in projects)
            {
                if (proj.name == name)
                    return proj;
            }
            return new MaintainProject();
        }

        public int getIndex(string name)
        {
            for (var i = 0; i < projects.Count; i++)
            {
                if (projects[i].name == name)
                    return i;
            }
            return -1;
        }

        public string set(string name)
        {
            return set(name, new MaintainProject());
        }

        public string set(MaintainProject project)
        {
            return set(project.name, project);
        }

        public string set(string name, MaintainProject project)
        {
            if (name.isNull())
                return "项目名不能为空";
            name = name.Trim();
            var idx = getIndex(name);
            if (idx < 0)
            {
                var proj = new MaintainProject();
                proj.name = name;
                projects.Add(proj);
                idx = projects.Count - 1;
            }
            if (project != null)
            {
                projects[idx].db_initial_path = project.db_initial_path;
                projects[idx].dbta_path = project.dbta_path;
                projects[idx].model_namespace = project.model_namespace;
            }
            return "";
        }

        public string delete(string name)
        {
            if (name.isNull())
                return "项目名不能为空";
            name = name.Trim();
            var idx = getIndex(name);
            if (idx < 0)
                return "未找到相关项目";
            projects.RemoveAt(idx);
            return "";
        }
    }

    public class MaintainProject
    {
        public string name = "";
        public string db_initial_path="";
        public string dbta_path = "";
        public string model_namespace = "";

        public MaintainProject copy()
        {
            var proj = new MaintainProject();
            proj.name = name;
            proj.db_initial_path = db_initial_path;
            proj.dbta_path = dbta_path;
            proj.model_namespace = model_namespace;
            return proj;
        }
    }
}
