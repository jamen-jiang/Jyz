using Jyz.Domain;
using Jyz.Infrastructure;
using Jyz.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jyz.Application
{
    public abstract class BaseService
    {
        protected JyzContext NewDB()
        {
            return new JyzContext();
        }
        /// <summary>
        /// 添加或修改实体前
        /// 添加(创建人赋值)
        /// 修改(修改人及修改时间赋值)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        protected void BeforeAdd<T>(T t) where T : ICreateEntity<Guid>
        {
            t.CreatedBy = CurrentUser.UserId;
            t.CreatedByName = CurrentUser.UserName;
            t.CreatedOn = DateTime.Now;
        }
        protected void BeforeModify<T>(T t) where T : IUpdateEntity<Guid>
        {
            t.UpdatedBy = CurrentUser.UserId;
            t.UpdatedByName = CurrentUser.UserName;
            t.UpdatedOn = DateTime.Now;
        }
        /// <summary>
        /// 生成树
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="node"></param>
        /// <param name="list"></param>
        /// <param name="tree"></param>
        protected void CreateTree<T>(T node, List<T> list, List<T> tree = null) where T : ITreeNode<T>
        {
            if (node == null || tree != null)
            {
                object id;
                if (node == null)
                    id = null;
                else
                    id = node.Id;
                List<T> parents = list.Where(x => Equals(x.PId,id)).ToList();
                foreach (var p in parents)
                {
                    tree.Add(p);
                    CreateTree(p, list);
                }
            }
            else
            {
                var childrens = list.Where(x => Equals(x.PId, node.Id)).ToList();
                foreach (var c in childrens)
                {
                    node.Children.Add(c);
                    CreateTree(c, list);
                }
            }
        }
        /// <summary>
        /// 获取当前Id及下面节点的Id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="idList"></param>
        /// <param name="id"></param>
        /// <param name="isFirst"></param>
        protected void GetCurrentAndChildrenIds<T>(List<T> list, List<object> idList, string id, bool isFirst = false) where T : ITreeNode
        {
            if (isFirst)
                idList.Add(id);
            var childrens = list.Where(x => Equals(x.PId,id)).Select(s => s.Id).ToList();
            if (childrens.Count > 0)
            {
                idList.AddRange(childrens);
                foreach (string cId in childrens)
                {
                    GetCurrentAndChildrenIds(list, idList, cId);
                }
            }
        }
        /// <summary>
        /// 获取当前Id及父节点的Id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="idList"></param>
        /// <param name="t"></param>
        protected void GetCurrentAndParentIds<T>(List<T> list, List<object> idList, T t) where T : ITreeNode
        {
            idList.Add(t.Id);
            var parent = list.FirstOrDefault(x =>Equals(x.Id,t.PId));
            if (parent!=null)
            {
                GetCurrentAndParentIds(list, idList, parent);
            }
        }
        /// <summary>
        /// 获取当前对象及父节点对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="idList"></param>
        /// <param name="t"></param>
        protected void GetCurrentAndParents<T>(List<T> list, List<T> outList, T t) where T : ITreeNode
        {
            outList.Add(t);
            var parent = list.FirstOrDefault(x => Equals(x.Id, t.PId));
            if (parent != null)
            {
                GetCurrentAndParents(list, outList, parent);
            }
        }
    }
}
