using System.Runtime.CompilerServices;
using Unity.Collections.LowLevel.Unsafe;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace Pixeye.Actors
{
  [Il2CppSetOption(Option.NullChecks | Option.ArrayBoundsChecks | Option.DivideByZeroChecks, false)]
  public static partial class EntityImplOld
  {
    internal static void CreateFirst()
    {
      int id;
      byte age = 0;

      if (ent.entStack.length > 0)
      {
        ref var pop = ref ent.entStack.source[--ent.entStack.length];
        id = pop.id;
        unchecked
        {
          age = pop.age;
        }
      }
      else
        id = ent.lastID++;

      ent entity;
      entity.id = id;
      entity.age = age;
      Create(entity);
      ProcessorEcs.Set(entity, -1, ProcessorEcs.Action.Activate);
    }

    public static ent Create(scn layer)
    {
      Create(layer.id, out var entity);
      return entity;
    }

    public static ent Create()
    {
      //Create(layer.id, out var entity);
      return default;
    }

    // public static ent Create()
    // {
    // //  Create(Starter.ActiveLayer.id, out var entity);
    //   return entity;
    // }

    public static ent Create(int layerIndex, ModelComposer model)
    {
      Create(layerIndex, out var entity);
      model(entity);
      return entity;
    }

    // public static ent Create(ModelComposer model)
    // {
    // //  Create(Starter.ActiveLayer.id, out var entity);
    //   model(entity);
    //   return entity;
    // }

    public static ent Create(string prefabID, Vector3 position = default, bool pooled = false)
    {
      int id;
      byte age = 0;

      if (ent.entStack.length > 0)
      {
        ref var pop = ref ent.entStack.source[--ent.entStack.length];
        id = pop.id;
        unchecked
        {
          age = pop.age;
        }
      }
      else
        id = ent.lastID++;

      ent entity;
      entity.id = id;
      entity.age = age;

      Create(entity, pooled);
      Transforms[id] = pooled ? Obj.Spawn(Pool.Entities, prefabID, position) : Obj.Spawn(prefabID, position);

      ProcessorEcs.Set(entity, -1, ProcessorEcs.Action.Activate);
      return entity;
    }

    public static ent Create(string prefabID, ModelComposer model, Vector3 position = default, bool pooled = false)
    {
      int id;
      byte age = 0;

      if (ent.entStack.length > 0)
      {
        ref var pop = ref ent.entStack.source[--ent.entStack.length];
        id = pop.id;
        unchecked
        {
          age = pop.age;
        }
      }
      else
        id = ent.lastID++;

      ent entity;
      entity.id = id;
      entity.age = age;

      Create(entity, pooled);
      Transforms[id] = pooled ? Obj.Spawn(Pool.Entities, prefabID, position) : Obj.Spawn(prefabID, position);
      model(entity);

      ProcessorEcs.Set(entity, -1, ProcessorEcs.Action.Activate);

      return entity;
    }

    public static ent Create(string prefabID, Transform parent, Vector3 position = default, bool pooled = false)
    {
      byte age = 0;
      int id;
      if (ent.entStack.length > 0)
      {
        ref var pop = ref ent.entStack.source[--ent.entStack.length];
        id = pop.id;
        unchecked
        {
          age = pop.age;
        }
      }
      else
        id = ent.lastID++;

      ent entity;
      entity.id = id;
      entity.age = age;
      Create(entity, pooled);
      Transforms[id] = pooled ? Obj.Spawn(1, prefabID, parent, position) : Obj.Spawn(prefabID, parent, position);
      ProcessorEcs.Set(in entity, -1, ProcessorEcs.Action.Activate);
      return entity;
    }

    public static ent Create(GameObject prefab, Transform parent, Vector3 position = default, bool pooled = false)
    {
      byte age = 0;
      int id;
      if (ent.entStack.length > 0)
      {
        ref var pop = ref ent.entStack.source[--ent.entStack.length];
        id = pop.id;
        unchecked
        {
          age = pop.age;
        }
      }
      else
        id = ent.lastID++;

      ent entity;
      entity.id = id;
      entity.age = age;
      Create(entity, pooled);
      Transforms[id] = pooled ? Obj.Spawn(1, prefab, parent, position) : Obj.Spawn(prefab, parent, position);
      ProcessorEcs.Set(in entity, -1, ProcessorEcs.Action.Activate);
      return entity;
    }

    public static ent Create(GameObject prefab, Vector3 position = default, bool pooled = false)
    {
      int id;
      byte age = 0;

      if (ent.entStack.length > 0)
      {
        ref var pop = ref ent.entStack.source[--ent.entStack.length];
        id = pop.id;
        unchecked
        {
          age = pop.age;
        }
      }
      else
        id = ent.lastID++;


      ent entity;
      entity.id = id;
      entity.age = age;


      Create(entity, pooled);
      Transforms[id] = pooled ? Obj.Spawn(Pool.Entities, prefab, position) : Obj.Spawn(prefab, position);

      ProcessorEcs.Set(entity, -1, ProcessorEcs.Action.Activate);
      return entity;
    }

    public static ent Create(GameObject prefab, ModelComposer model, Vector3 position = default, bool pooled = false)
    {
      int id;
      byte age = 0;

      if (ent.entStack.length > 0)
      {
        ref var pop = ref ent.entStack.source[--ent.entStack.length];
        id = pop.id;
        unchecked
        {
          age = pop.age;
        }
      }
      else
        id = ent.lastID++;


      ent entity;
      entity.id = id;
      entity.age = age;

      Create(entity, pooled);
      Transforms[id] = pooled ? Obj.Spawn(Pool.Entities, prefab, position) : Obj.Spawn(prefab, position);
      model(entity);
      ProcessorEcs.Set(entity, -1, ProcessorEcs.Action.Activate);
      return entity;
    }

    public static ent CreateFor(GameObject prefab, ModelComposer model)
    {
      int id;
      byte age = 0;

      if (ent.entStack.length > 0)
      {
        ref var pop = ref ent.entStack.source[--ent.entStack.length];
        id = pop.id;
        unchecked
        {
          age = pop.age;
        }
      }
      else
        id = ent.lastID++;

      ent entity;
      entity.id = id;
      entity.age = age;

      Create(entity);
      Transforms[id] = prefab.transform;
      model(entity);
      ProcessorEcs.Set(entity, -1, ProcessorEcs.Action.Activate);
      return entity;
    }

    public static ent CreateFor(GameObject obj)
    {
      int id;
      byte age = 0;

      if (ent.entStack.length > 0)
      {
        ref var pop = ref ent.entStack.source[--ent.entStack.length];
        id = pop.id;
        unchecked
        {
          age = pop.age;
        }
      }
      else
        id = ent.lastID++;

      ent entity;
      entity.id = id;
      entity.age = age;

      Create(entity);
      Transforms[id] = obj.transform;
      ProcessorEcs.Set(entity, -1, ProcessorEcs.Action.Activate);
      return entity;
    }

    public static ent CreateFor(string name)
    {
      int id;
      byte age = 0;

      if (ent.entStack.length > 0)
      {
        ref var pop = ref ent.entStack.source[--ent.entStack.length];
        id = pop.id;
        unchecked
        {
          age = pop.age;
        }
      }
      else
        id = ent.lastID++;

      ent entity;
      entity.id = id;
      entity.age = age;

      Create(entity);

      Transforms[id] = GameObject.Find(name).transform;
      ProcessorEcs.Set(entity, -1, ProcessorEcs.Action.Activate);
      return entity;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static void Create(int layerIndex, out ent entity)
    {
      int id;
      byte age = 0;

      if (ent.entStack.length > 0)
      {
        ref var pop = ref ent.entStack.source[--ent.entStack.length];
        id = pop.id;
        unchecked
        {
          age = pop.age;
        }
      }
      else
        id = ent.lastID++;

      entity.id = id;
      entity.age = age;
      Create(entity);
      ProcessorEcs.Set(entity, -1, ProcessorEcs.Action.Activate);
      // Starter.Starters[layerIndex].entities.Add(entity);
    }

    public static Transform[] Transforms;
    internal static int[,] Generations;
    public static readonly int sizeBufferTags = UnsafeUtility.SizeOf<CacheTags>();
  }
}