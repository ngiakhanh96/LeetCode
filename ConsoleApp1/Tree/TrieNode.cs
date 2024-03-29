﻿namespace ConsoleApp1.Tree;

public class TrieNode<T>
{
    public T Val { get; set; }

    public bool IsWord { get; set; }

    public TrieNode<T>[] Children { get; } = new TrieNode<T>[26];

    public TrieNode()
    {

    }

    public TrieNode(T val, bool isWord = false)
    {
        Val = val;
        IsWord = isWord;
    }

    public void Insert(string word)
    {
        var currentNode = this;

        foreach (var chr in word)
        {
            currentNode.Children[chr - 'a'] ??= new TrieNode<T>();
            currentNode = currentNode.Children[chr - 'a'];
        }
        currentNode.IsWord = true;
    }

    public void StackInsert(string word, int position = 0)
    {
        var chr = word[position];
        Children[chr - 'a'] ??= new TrieNode<T>();

        if (position == word.Length - 1)
        {
            Children[chr - 'a'].IsWord = true;
        }
        else
        {
            Children[chr - 'a'].StackInsert(word, position + 1);
        }
    }

    public bool Search(string word)
    {
        var currentNode = this;

        foreach (var chr in word)
        {
            if (currentNode.Children[chr - 'a'] == null)
            {
                return false;
            }

            currentNode = currentNode.Children[chr - 'a'];
        }

        return currentNode.IsWord;
    }

    public bool StartsWith(string prefix)
    {
        var currentNode = this;
        foreach (var chr in prefix)
        {
            if (currentNode.Children[chr - 'a'] == null)
            {
                return false;
            }

            currentNode = currentNode.Children[chr - 'a'];
        }

        return true;
    }
}