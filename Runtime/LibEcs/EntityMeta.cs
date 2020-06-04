﻿using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;


namespace Pixeye.Actors
{
  [StructLayout(LayoutKind.Sequential)]
  public unsafe struct EntityMeta
  {
    const int size = sizeof(ushort);

    public byte componentsLength;
    public byte componentsAmount;
    public byte groupsLength;
    public byte groupsAmount;

    public byte age;

    public bool isDirty; //dirty allows to set all components for a new entity in one init command
    public bool isAlive;
    public ent parent;

    public CacheTags tags;

    public ushort* components;
    public ushort* groups;


    public void Initialize()
    {
      componentsLength = 6;
      groupsLength     = 6;

      components = (ushort*) Marshal.AllocHGlobal(componentsLength * size);
      groups     = (ushort*) Marshal.AllocHGlobal(groupsLength * size);

      componentsAmount = 0;
      groupsAmount     = 0;

      tags = new CacheTags();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void AddComponent(int type)
    {
      if (componentsLength == componentsAmount)
      {
        componentsLength = (byte) (componentsAmount << 1); // not safe
        components =
          (ushort*) Marshal.ReAllocHGlobal((IntPtr) components, (IntPtr) (componentsLength * sizeof(ushort)));
      }

      components[componentsAmount++] = (ushort) type;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void RemoveComponent(int type, int entityID)
    {
      for (var tRemoveIndex = 0; tRemoveIndex < componentsAmount; tRemoveIndex++)
      {
        if (components[tRemoveIndex] == type)
        {
          Storage.All[type].toDispose.Add(entityID);
          for (var j = tRemoveIndex; j < componentsAmount - 1; ++j)
            components[j] = components[j + 1];
          componentsAmount--;
          break;
        }
      }
    }

    public void AddGroup(int type)
    {
      if (groupsLength == groupsAmount)
      {
        groupsLength = (byte) (groupsAmount << 1); // not safe
        groups =
          (ushort*) Marshal.ReAllocHGlobal((IntPtr) groups, (IntPtr) (groupsLength * sizeof(ushort)));
      }

      groups[groupsAmount++] = (ushort) type;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void RemoveGroup(int type)
    {
      for (var tRemoveIndex = 0; tRemoveIndex < componentsAmount; tRemoveIndex++)
      {
        if (groups[tRemoveIndex] == type)
        {
          for (var j = tRemoveIndex; j < groupsAmount - 1; ++j)
            groups[j] = groups[j + 1];
          groupsAmount--;
          break;
        }
      }
    }
  }

  public struct EntityManagedMeta
  {
    public bool isPooled;
    public bool isNested;
    internal LayerCore layer;

    internal Transform transform;

    //internal int[] generations;
    internal int[] signature;
    internal ents childs;

    public void Initialize()
    {
      childs = new ents();
      //generations        = new int[Kernel.Settings.SizeGenerations];
      signature = new int[Kernel.Settings.SizeGenerations];
    }
  }
}